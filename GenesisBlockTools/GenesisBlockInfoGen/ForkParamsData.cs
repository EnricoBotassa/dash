using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public enum NetType
    {
        MainAlert       = 0,
        TestAlert       = 1,
        Main            = 2,
        MainSpork       = 3,
        TestNetSpork    = 4,
        EndOfList
    }

    public class ForkParamsData
    {
        public Dictionary<NetType, KeyPairEC> KeyPairs = new Dictionary<NetType, KeyPairEC>();
        public Dictionary<GenBlockType, GenesisBlockInfo> GenesisBlocks = new Dictionary<GenBlockType, GenesisBlockInfo>();

    }
}
