using ConsoleControl;
using GenesisBlockInfoGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum PortsType
{
    MainPort = 0,
    TestPort,
    TestRegPort,
    MainPortRPC,
    TestPortRPC,
    TestRegPortRPC
}

namespace DashForkGenerator
{
    public partial class ForkGenerator : Form
    { 
        private string SourcePath = "";
        private const string ParamSrcFile = "chainparams_const";

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
            OutputConsole.AutoScroll = true;
        }

        public void ChooseFolder()
        {
            if (FolderBrowserSrc.ShowDialog() == DialogResult.OK)
            {
                SourcePath = FolderBrowserSrc.SelectedPath;
                Box_Folder.Text = SourcePath;

                string path = $"{SourcePath}\\{ParamSrcFile}.h";
                if (File.Exists(path))
                    ChBox_SrcFinded.Checked = true;
            }
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
            this.BeginInvoke((Action)delegate ()
            {

                OutputConsole.WriteOutput($"{msg}", color);
                OutputConsole.InternalRichTextBox.ScrollToCaret();
            });
        }

        private void WriteLog(string msg)
        {
            WriteLog(msg, Color.LimeGreen);
        }

        private void WriteLnLog(string msg, Color color)
        {
            WriteLog($"{msg}\n", color);
        }

        private void WriteLnLog(string msg)
        {
            WriteLog($"{msg}\n");
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

            SetFlagGenesisByNetType(GenBlockType.Main,    ChBox_BlockMain);
            SetFlagGenesisByNetType(GenBlockType.TestNet, ChBox_BlockTest);
            SetFlagGenesisByNetType(GenBlockType.RegTest, ChBox_BlockRegTest);
        }

        private void SetFlagKeyPairByNetType(NetType type, CheckBox chb)
        {
            if (ForkData.KeyPairs.ContainsKey(type))
                chb.Checked = true;
            else
                chb.Checked = false;
        }

        private void SetFlagGenesisByNetType(GenBlockType type, CheckBox chb)
        {
            if (ForkData.GenesisBlocks.ContainsKey(type))
                chb.Checked = true;
            else
                chb.Checked = false;
        }

        private void GUITimer_Tick(object sender, EventArgs e)
        {
            if (InPairsGen || ForkData.KeyPairs.ContainsKey(NetType.Main))
                LockObject(Btn_KeyPairGen);
            else
                LockObject(Btn_KeyPairGen, true);

            if (InBlocksGen || ForkData.GenesisBlocks.ContainsKey(GenBlockType.Main) || !ForkData.KeyPairs.ContainsKey(NetType.Main))
                LockObject(Btn_GenesisGen);
            else
                LockObject(Btn_GenesisGen, true);

            if (InPairsGen || InBlocksGen || !ForkData.KeyPairs.ContainsKey(NetType.Main) ||
               !ForkData.GenesisBlocks.ContainsKey(GenBlockType.Main) ||
               !ForkData.GenesisBlocks.ContainsKey(GenBlockType.TestNet) ||
               !ForkData.GenesisBlocks.ContainsKey(GenBlockType.RegTest) ||
               !ChBox_SrcFinded.Checked
               )
                LockObject(Btn_Fork);
            else
                LockObject(Btn_Fork, true);
        }

        private void ForkGenerator_Activated(object sender, EventArgs e)
        {
            OutputConsole.AutoScroll = false;
            //OutputConsole.AutoScroll = true;

            if (!ActivatedConsole)
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

        private void Btn_Folder_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void Btn_Fork_Click(object sender, EventArgs e)
        {
            string template = $"{ParamSrcFile}.tpl";

            var portsDict = new Dictionary<PortsType, int>();
            portsDict.Add(PortsType.MainPort, (int)UD_MainPort.Value);
            portsDict.Add(PortsType.TestPort, (int)UD_TestPort.Value);
            portsDict.Add(PortsType.TestRegPort, (int)UD_TestRegPort.Value);
            portsDict.Add(PortsType.MainPortRPC, (int)UD_MainRPC.Value);
            portsDict.Add(PortsType.TestPortRPC, (int)UD_TestRPC.Value);
            portsDict.Add(PortsType.TestRegPortRPC, (int)UD_TestRegRPC.Value);

            var uniq = portsDict.Select(o => o.Value).Distinct().ToList();

            if(uniq.Count < 6)
            {
                string message = $"You entered duplicate ports, bitch!";
                string caption = "Malfunction!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            if (File.Exists(template))
            {
                using (StreamReader sr = new StreamReader(template))
                {
                    string tmplstr = sr.ReadToEnd();

                    // replacing parameters
                    tmplstr = tmplstr.Replace($"%zsvTimestamp%", TextBox_SeedPhrase.Text);

                    // main net massage start hexes 
                    var hexes = GetRandomBytes(4);
                    for(int i = 0; i < hexes.Count; i++)
                        tmplstr = tmplstr.Replace($"%main_hex{i+1}%", hexes[i].ToString("x"));

                    // main net pub key
                    tmplstr = tmplstr.Replace($"%main_pub%", ForkData.KeyPairs[NetType.Main].PubKeyByteHexStr);
                    // main net alert pub key
                    tmplstr = tmplstr.Replace($"%main_alert_pub%", ForkData.KeyPairs[NetType.MainAlert].PubKeyByteHexStr);
                    // main net port
                    tmplstr = tmplstr.Replace($"%main_port%", portsDict[PortsType.MainPort].ToString());

                    // test net massage start hexes 
                    hexes = GetRandomBytes(4);
                    for (int i = 0; i < hexes.Count; i++)
                        tmplstr = tmplstr.Replace($"%test_hex{i + 1}%", hexes[i].ToString("x"));

                    // test net alert pub key
                    tmplstr = tmplstr.Replace($"%test_alert_pub%", ForkData.KeyPairs[NetType.TestAlert].PubKeyByteHexStr);
                    // test net port
                    tmplstr = tmplstr.Replace($"%test_port%", portsDict[PortsType.TestPort].ToString());
                    // regtest net port
                    tmplstr = tmplstr.Replace($"%regtest_port%", portsDict[PortsType.TestRegPort].ToString());

                    // regtest net massage start hexes 
                    hexes = GetRandomBytes(4);
                    for (int i = 0; i < hexes.Count; i++)
                        tmplstr = tmplstr.Replace($"%regtest_hex{i + 1}%", hexes[i].ToString("x"));

                    // Main net
                    //  genesis block timestamp
                    tmplstr = tmplstr.Replace($"%main_timestamp%", ForkData.GenesisBlocks[GenBlockType.Main].StartTime.ToString());
                    //  genesis block nonce
                    tmplstr = tmplstr.Replace($"%main_nonce%", ForkData.GenesisBlocks[GenBlockType.Main].Nonce.ToString());
                    //  genesis block hash
                    tmplstr = tmplstr.Replace($"%main_hash%", ForkData.GenesisBlocks[GenBlockType.Main].GenesisHash);

                    // Test net
                    //  genesis block timestamp
                    tmplstr = tmplstr.Replace($"%test_timestamp%", ForkData.GenesisBlocks[GenBlockType.TestNet].StartTime.ToString());
                    //  genesis block nonce
                    tmplstr = tmplstr.Replace($"%test_nonce%", ForkData.GenesisBlocks[GenBlockType.TestNet].Nonce.ToString());
                    //  genesis block hash
                    tmplstr = tmplstr.Replace($"%test_hash%", ForkData.GenesisBlocks[GenBlockType.TestNet].GenesisHash);

                    // RegTest net
                    //  genesis block timestamp
                    tmplstr = tmplstr.Replace($"%regtest_timestamp%", ForkData.GenesisBlocks[GenBlockType.RegTest].StartTime.ToString());
                    //  genesis block nonce
                    tmplstr = tmplstr.Replace($"%regtest_nonce%", ForkData.GenesisBlocks[GenBlockType.RegTest].Nonce.ToString());
                    //  genesis block hash
                    tmplstr = tmplstr.Replace($"%regtest_hash%", ForkData.GenesisBlocks[GenBlockType.RegTest].GenesisHash);

                    // Merkle hash
                    tmplstr = tmplstr.Replace($"%merkle_hash%", ForkData.GenesisBlocks[GenBlockType.Main].MerkleHash);

                    // RPC ports
                    // main
                    tmplstr = tmplstr.Replace($"%main_rpc%", portsDict[PortsType.MainPortRPC].ToString());
                    // test
                    tmplstr = tmplstr.Replace($"%test_rpc%", portsDict[PortsType.TestPortRPC].ToString());
                    // regtest
                    tmplstr = tmplstr.Replace($"%regtest_rpc%", portsDict[PortsType.TestRegPortRPC].ToString());

                    // now we must rewrite file chainparams_const.h in src directory
                    string path = $"{SourcePath}\\{ParamSrcFile}.h";
                    if(File.Exists(path))
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.Write(tmplstr);
                        }
                    }
                }
            }
            else
            {
                string message = $"There is no template file {template}, bitch!";
                string caption = "Malfunction!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private List<byte> GetRandomBytes(int num)
        {
            var rnd = new Random();
            var bytes = new List<byte>();

            for(int i = 0; i < num; i++)
            {
                bytes.Add((byte)rnd.Next((int)byte.MaxValue));
            }

            return bytes;
        }
    }
}
