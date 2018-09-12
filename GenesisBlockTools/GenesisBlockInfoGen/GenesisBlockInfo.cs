using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public enum GenBlockType
    {
        Main        = 0,
        TestNet     = 1,
        RegTest     = 2,
        EndOfList
    }

    public class GenesisBlockInfo
    {
        public string   MerkleHash = "";
        public string   PubKeyHex = "";
        public string   PszTimestamp = "";
        public uint     NBits = 0;
        public ulong    StartTime = 0;
        public ulong    Nonce = 0;
        public string   GenesisHash = "";
    }
}
