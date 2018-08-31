using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public enum TypeNet
    {
        Main            = 0,
        MainAlert       = 1,
        MainSpork       = 2,
        TestNetAlert    = 3,
        TestNetSpork    = 4,
    }

    public class GenesisGen
    {
        public void StartGeneration(string pszTimestamp, ulong unixTime)
        {
            var keyPairs = new Dictionary<TypeNet, KeyPairEC>();

            // 1st: let's generate a few EC key pairs
            for (int type = (int)TypeNet.Main; type <= (int)TypeNet.TestNetSpork; type++)
                keyPairs.Add((TypeNet)type, DashEC.SecP256r1KeyPairGen());

            // 2nd: genesis blocks generation

        }
    }
}
