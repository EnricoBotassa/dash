using GenesisBlockInfoGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashForkGenerator
{
    public partial class ForkGenerator : Form
    {
        TextWriter _writer = null;

        private WebLogger Logger = new WebLogger(Color.LightSeaGreen, 0, false, 12);
        private ForkParamsData ForkData = new ForkParamsData();
        private const int LINE_WIDTH = 100;
        private bool ActivatedConsole = false;

        private bool InPairsGen  = false;
        private bool InBlocksGen = false;

        Thread BlockGetThread = null;

        public ForkGenerator()
        {
            InitializeComponent();

            Timer_Log.Start();
            MainTimer.Start();
            GUITimer.Start();

            OutputConsole.Font = new Font("Consolas", 12, FontStyle.Regular);
        }

        private void LockObject(Control obj, bool enabled = false)
        {
            if(obj.Enabled != enabled)
                obj.Enabled = enabled;
        }

        private string FillSpaces(int num)
        {
            string str = "";
            for (int i = 0; i < num; i++)
                str += " ";
            return str;
        }

        private void WriteCategory(string name, string msg, int msgLen = 64)
        {
            WriteLog(name, Color.Yellow);
            int numSpaces = 0;

            //split msg
            while(msg.Length > msgLen)
            {
                var str = msg.Substring(0, msgLen);
                msg = msg.Substring(msgLen);
                WriteLnLog($"{FillSpaces(numSpaces)}{str}", Color.White);
                numSpaces = name.Length;
            }
            WriteLnLog($"{FillSpaces(numSpaces)}{msg}", Color.White);
        }

        private void WriteLog(string msg, Color color)
        {
            OutputConsole.WriteOutput($"{msg}", color);
            //Logger.AddOnePhraseLine(msg, LINE_WIDTH, color, style);
        }

        private void WriteLog(string msg)
        {
            OutputConsole.WriteOutput($"{msg}", Color.LimeGreen);
            //Logger.AddOnePhraseLine(msg, LINE_WIDTH, style);
        }

        private void WriteLnLog(string msg, Color color)
        {
            OutputConsole.WriteOutput($"{msg}\n", color);
            //Logger.AddOnePhraseLine(msg, LINE_WIDTH, color, style);
        }

        private void WriteLnLog(string msg)
        {
            OutputConsole.WriteOutput($"{msg}\n", Color.LimeGreen);
            //Logger.AddOnePhraseLine(msg, LINE_WIDTH, style);
        }

        private void TextBox_CoinName_TextChanged(object sender, EventArgs e)
        {

            string coin = TextBox_CoinName.Text;
            string prefix = coin.ToLower();
            string bold = coin.ToUpper();
            string name = prefix;

            if (coin.Length > 0)
                name = $"{bold[0]}{name.Substring(1)}";

            TextBox_CName.Text = name;
            TextBox_CPrefix.Text = prefix;
            TextBox_CBold.Text = bold;

        }

        private void Timer_Log_Tick(object sender, EventArgs e)
        {/*
            OutputConsole.ClearOutput();
            Logger.WriteLog(OutputConsole);*/
        }

        private void Btn_KeyPairGen_Click(object sender, EventArgs e)
        {

            InPairsGen = true;
            //Logger.SetloadingMode();

            WriteLnLog($"");
            WriteLnLog($"Generating EC (secp256r1) key pairs ...");

            ForkData.KeyPairs = new Dictionary<NetType, KeyPairEC>();

            for (int i = 0; i < (int)NetType.EndOfList; i++)
            {
                WriteLnLog($"");
                WriteLnLog($" {(NetType)i}:");
                var keyPair = DashEC.SecP256r1KeyPairGen();
                ForkData.KeyPairs.Add((NetType)i, keyPair);
                WriteCategory(" PrivKey: ", keyPair.PrivKeyByteHexStr);
                WriteCategory(" PubKey:  ", keyPair.PubKeyByteHexStr);
            }

            //Logger.SetloadingMode(false);
            InPairsGen = false;
        }

        private uint GetUnixTime(DateTime dt)
        {
            return (uint)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private void GenesisProc()
        {
            InBlocksGen = true;
            //Logger.SetloadingMode();

            WriteLnLog($"");
            WriteLnLog($"Generating genesis blocks ...");

            ForkData.GenesisBlocks = new Dictionary<GenBlockType, GenesisBlockInfo>();
            for (int i = 0; i < (int)GenBlockType.EndOfList; i++)
            {
                WriteLnLog($"");
                WriteLnLog($" {(GenBlockType)i} genesis block:", Color.LightSkyBlue);

                string pubKey = ForkData.KeyPairs[NetType.Main].PubKeyByteHexStr;

                var dtSet = DT_StartDate.Value;
                var dt = new DateTimeOffset(dtSet.Year, dtSet.Month, dtSet.Day, 
                                            (int)UD_Hour.Value, (int)UD_Minute.Value, (int)UD_Second.Value, new TimeSpan());

                ulong timeBits = (ulong)dt.ToUnixTimeSeconds();

                WriteCategory("     PubKey: ", pubKey);

                BlockSolver s = new BlockSolver(
                    pubKey,
                    TextBox_SeedPhrase.Text,    // timestamp
                    timeBits + (ulong)i,        // timestamp bits
                    0,                          // nBits
                    0,                          // nTime
                    0,                          // nNonce
                    2);                         // threads

                var subRes = s.GetBlockInfo();
                WriteCategory("   TimeBits: ", $"{subRes.StartTime}");
                WriteCategory("      Nbits: ", $"{subRes.NBits.ToString("X2")}");
                WriteCategory(" MerkleHash: ", $"{subRes.MerkleHash}");

                var res = s.Solve();

                WriteCategory("      Nonce: ", $"{subRes.Nonce}");
                WriteCategory("  BlockHash: ", $"{subRes.GenesisHash}");

                ForkData.GenesisBlocks.Add((GenBlockType)i, res);
            }

            //Logger.SetloadingMode(false);
            InBlocksGen = false;
        }

        private void Btn_GenesisGen_Click(object sender, EventArgs e)
        {
            LockObject(Btn_GenesisGen);
            BlockGetThread = new Thread(GenesisProc);
            BlockGetThread.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            SetFlagKeyPairByNetType(NetType.MainAlert,      ChBox_MainAlert);
            SetFlagKeyPairByNetType(NetType.TestAlert,      ChBox_TestAlert);
            SetFlagKeyPairByNetType(NetType.Main,           ChBox_Main);
            SetFlagKeyPairByNetType(NetType.MainSpork,      ChBox_MainSpork);
            SetFlagKeyPairByNetType(NetType.TestNetSpork,   ChBox_TestNetSpork);
        }

        private void SetFlagKeyPairByNetType(NetType type, CheckBox chb)
        {
            if (ForkData.KeyPairs.ContainsKey(type))
                chb.Checked = true;
            else
                chb.Checked = false;
        }

        private void GUITimar_Tick(object sender, EventArgs e)
        {
            if (InPairsGen || ForkData.KeyPairs.ContainsKey(NetType.Main))
                LockObject(Btn_KeyPairGen);
            else
                LockObject(Btn_KeyPairGen, true);

            if (InBlocksGen || ForkData.GenesisBlocks.ContainsKey(GenBlockType.Main) || !ForkData.KeyPairs.ContainsKey(NetType.Main))
                LockObject(Btn_GenesisGen);
            else
                LockObject(Btn_GenesisGen, true);
        }

        private void ForkGenerator_Activated(object sender, EventArgs e)
        {
            if(!ActivatedConsole)
            {
                WriteLnLog("Greatings! You are welcome to the automatic Bash fork generator!");
                WriteLnLog("You need to do a few steps to build your own altcoin based on Bash:");
                WriteLnLog(" # 1st: generate complect of 5 secp251r1 key pairs for mainalert,");
                WriteLnLog("        testalert, main, mainspork, testnetspork;");
                WriteLnLog(" # 2nd: generate genesis blocks for main, test and regtest nets.");

                ActivatedConsole = true;
            }            
        }

        private void ForkGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BlockGetThread != null && BlockGetThread.IsAlive)
                BlockGetThread.Abort();
        }
    }
}
