using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GenesisBlockInfoGen
{
    class BlockSolver
    {
        public Block genesis { get; set; }
        public uint time { get; set; }
        public uint nonce { get; set; }

        protected long hashesSinceLastTick;
        protected System.Timers.Timer hashTimer { get; set; }
        protected Mutex jobMutex { get; set; }
        protected bool jobDone { get; set; }
        protected bool isFirstJob { get; set; }
        public uint WorkerCount { get; set; }

        public BlockSolver(string publicKey, string timestamp, uint timestampBits, uint nBits, uint startTime, uint startNonce, uint workerCount)
        {
            genesis = new Block();

            Transaction txNew = new Transaction();
            txNew.vin.Add(new TxIn());
            txNew.vout.Add(new TxOut());

            string prefix = "";
            if (timestamp.Length > 76)
                prefix = "4c";

            prefix += $"{Convert.ToChar(timestamp.Length)}";

            string hexStr = "04ffff001d0104";
            var startBytes = Utilities.StringToByteArrayFastest(hexStr);
            string str = Encoding.ASCII.GetString(startBytes);

            txNew.vin[0].scriptSig = new Script();
            txNew.vin[0].scriptSig.Buffer = startBytes.ToList();//timestampBits;
                                                                //txNew.vin[0].scriptSig += prefix;
            txNew.vin[0].scriptSig += timestamp;

            var insc = Utilities.GetBytesString(txNew.vin[0].scriptSig.Buffer);

            txNew.vout[0].nValue = 50 * Utilities.COIN;
            txNew.vout[0].scriptPubKey = new Script();
            txNew.vout[0].scriptPubKey += Utilities.StringToByteArrayFastest(publicKey);
            txNew.vout[0].scriptPubKey += OpCodeType.OP_CHECKSIG;

            // Original transaction check
            var txGenBytes = txNew.Serialize();
            var originalTx = "01000000010000000000000000000000000000000000000000000000000000000000000000ffffffff3104ffff001d01042949742773205a616c676f436f696e2074696d652120486520636f6d65732e2030312f31302f32303138ffffffff0100f2052a010000004341048c5702648e9c7ff4fb64affae1e3ce7150bb73fd66232af229ec29ea8d2568817870c1e24e2bf58410dcd72ba7b3fc1aaab2b88e58b2d595405a0d5aae8b03e8ac00000000";
            byte[] txOriginalBytes = Utilities.StringToByteArrayFastest(originalTx);
            Utilities.CompareTransactions(txOriginalBytes, txGenBytes);

            genesis.vtx.Add(txNew);
            genesis.hashPrevBlock = 0;
            Console.WriteLine($"Merkle root int: {genesis.BuildMerkleTree()}");
            Console.WriteLine($"Merkle root: {Utilities.GetBytesString(genesis.BuildMerkleTree().ToByteArray(), false)}");
            Console.WriteLine($"Merkle swap: {Utilities.GetBytesString(Utilities.ByteSwap(genesis.BuildMerkleTree().ToByteArray()), false)}");

            if (nBits == 0)
            {
                // X11
                nBits = 0x1e0ffff0;
                // SHA256
                //nBits = 0x1d00ffff;
            }

            BigInteger diff = Utilities.GetBigIntegerFromCompact(nBits);
            Console.WriteLine();
            Console.WriteLine($"Target: {diff}");
            Console.WriteLine($"Difficulty: {Utilities.GetBytesString(Utilities.ByteSwap(Utilities.BytePad(diff.ToByteArray(), 32, 0)), false)}");
            Console.WriteLine();
            genesis.hashMerkleRoot = genesis.BuildMerkleTree();

            // Original merkle root check
            // real merkle root
            //03ee2f8f83e42b3f6db2104a1076f5e299cc4da4a670ef5d659f0e373ee9e80d
            //var mrb = Utilities.BigInt256ToBytes(genesis.hashMerkleRoot);
            //var mr = Utilities.GetBytesString(mrb, false);

            genesis.nVersion = 1;
            genesis.nBits = nBits;

            // Set the starting values
            time = startTime;
            nonce = startNonce;

            genesis.nTime = timestampBits;// time == 0 ? Utilities.GetCurrentTimestamp() : time;
            genesis.nNonce = nonce;

            jobMutex = new Mutex();
            jobDone = false;
            hashesSinceLastTick = 0;
            isFirstJob = true;
            WorkerCount = workerCount;
        }

        public void Solve()
        {
            // Environment.ProcessorCount

            // Start the monitoring timer
            hashTimer = new System.Timers.Timer(5000);
            hashTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            hashTimer.Enabled = true;

            Thread[] workers = new Thread[WorkerCount];

            Console.WriteLine($"Spawning {WorkerCount} workers to solve the genesis block...");

            // Spawn a worker thread for each processor we have on this machine
            for (var i = 0; i < WorkerCount; i++)
            {
                workers[i] = new Thread(new ThreadStart(JobWorker));
                workers[i].Start();
            }

            // Wait for the workers to complete
            for (var i = 0; i < WorkerCount; i++)
            {
                // Wait for the workers to complete
                workers[i].Join();
            }

            Console.WriteLine("Work complete.");

            //
            //			while (true) 
            //			{
            //				byte[] hash = genesis.GetHash ();
            //				uint last4 = BitConverter.ToUInt32 (hash, hash.Length - 4);
            //
            //				if (last4 == 0) 
            //				{
            //					hashTimer.Enabled = false;
            //					Console.WriteLine ();
            //					Console.WriteLine (" ** BLOCK SOLVED ** nNonce {0}, nTime {1}", genesis.nNonce, genesis.nTime);
            //					Console.WriteLine ("Block hash  : {0}", Utilities.GetBytesString (hash, false));
            //					Console.WriteLine ("Block pretty: {0}", Utilities.GetBytesString (Utilities.ByteSwap (hash), false));
            //
            //					Console.WriteLine ();
            //					byte[] blockBytes = genesis.Serialize ();
            //					Utilities.PrintBytes (blockBytes);Console.WriteLine ();
            //					Console.WriteLine ();
            //
            //					break;
            //				}
            //
            //				if (genesis.nNonce == uint.MaxValue) 
            //				{
            //					genesis.nTime++;
            //					genesis.nNonce = 0;
            //				}
            //				else
            //				{
            //					genesis.nNonce++;
            //				}
            //
            //				hashesSinceLastTick++;
            //
            //			}

        }

        protected uint[] GetNextJob()
        {
            if (jobMutex.WaitOne())
            {

                if (isFirstJob)
                {
                    // First job - don't increment or decrement
                    isFirstJob = false;
                }
                else
                {

                    // Get the next job
                    if (genesis.nNonce == uint.MaxValue)
                    {
                        genesis.nTime++;
                        genesis.nNonce = 0;
                    }
                    else
                    {
                        genesis.nNonce++;
                    }
                }

                var job = new uint[2] { genesis.nTime, genesis.nNonce };

                jobMutex.ReleaseMutex();

                return job;

            }
            else
            {
                return GetNextJob();
            }
        }

        protected void JobWorker()
        {
            // Get the header block template
            byte[] headerBlock = genesis.SerializeHeader();
            BigInteger difficulty = Utilities.GetBigIntegerFromCompact(genesis.nBits);


            while (!jobDone)
            {
                // Gext the next job
                uint[] job = GetNextJob();

                // Apply the job to the header
                // nTime  -> index 68-72
                // nNonce -> index 76-80
                BitConverter.GetBytes(job[0]).CopyTo(headerBlock, 68);
                BitConverter.GetBytes(job[1]).CopyTo(headerBlock, 76);

                // Get the hash of the block
                byte[] hash = Utilities.Hash(headerBlock);
                //byte[] hash = Utilities.Hash(headerBlock);

                // Check debug check - run one job
                //				if (jobMutex.WaitOne ()) {
                //					Utilities.PrintBytes (headerBlock); 
                //					Console.WriteLine ();
                //					Console.WriteLine ();
                //					Console.WriteLine ("Block hash  : {0}", Utilities.GetBytesString (hash, false));
                //					Console.WriteLine ("Block pretty: {0}", Utilities.GetBytesString (Utilities.ByteSwap (hash), false));
                //					jobMutex.ReleaseMutex ();
                //					return;
                //				}

                // Check the hash against the nBits difficulty target
                BigInteger hashVal = Utilities.BytesToBigInteger(hash, true);
                //Console.WriteLine($"Nonce = {nonce}; Hash = {hashVal}");
                // Nonce = 0; Hash = 19326981056617863134880086773070629952806055677845660736366947971517608913709
                //Thread.Sleep(1000);

                // Check if we have the winning block
                if (hashVal < difficulty)
                {

                    //
                    // FOUND THE BLOCK
                    //

                    // Stop the workers
                    if (jobMutex.WaitOne())
                    {

                        jobDone = true;
                        hashTimer.Enabled = false;

                        // Apply the final values
                        genesis.nTime = job[0];
                        genesis.nNonce = job[1];

                        // Show the magic
                        Console.WriteLine();
                        Console.WriteLine(" ** BLOCK SOLVED **");
                        Console.WriteLine($"Found at: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} ({Utilities.GetCurrentTimestamp()})");
                        Console.WriteLine($"nBits   : {genesis.nBits} (0x{Utilities.GetBytesString(Utilities.ByteSwap(BitConverter.GetBytes(genesis.nBits)), false)})");
                        Console.WriteLine($"nTime   : {genesis.nTime}");
                        Console.WriteLine($"nNonce  : {genesis.nNonce}");
                        Console.WriteLine();
                        Console.WriteLine($"Hash    : {Utilities.GetBytesString(hash, false)}");
                        Console.WriteLine($"Swapped : {Utilities.GetBytesString(Utilities.ByteSwap(hash), false)}");
                        Console.WriteLine($"Numeric : {hashVal}");
                        Console.WriteLine();

                        // Show the raw block
                        byte[] blockBytes = genesis.Serialize();
                        Utilities.PrintBytes(blockBytes);
                        Console.WriteLine();
                        Console.WriteLine();

                        jobMutex.ReleaseMutex();
                    }

                    // Get out of here
                    return;

                }

                // Not solved, iterate the hash counter and do the next one
                Interlocked.Increment(ref hashesSinceLastTick);

            }

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.Write($"\rHashrate: {hashesSinceLastTick / 5}/sec, nNonce={genesis.nNonce}, nTime={genesis.nTime}              ");
            Interlocked.Exchange(ref hashesSinceLastTick, 0);
        }
    }
}
