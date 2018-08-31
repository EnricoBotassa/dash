using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public class OutPoint : IByteSerializeable
    {
        public BigInteger hash { get; set; }
        public uint n { get; set; }

        public OutPoint()
        {
            hash = new BigInteger(0);
            n = uint.MaxValue;
        }

        #region IByteSerializeable implementation

        public byte[] Serialize()
        {
            List<byte> buffer = new List<byte>();

            // 32 byte hash
            buffer.AddRange(Utilities.BigInt256ToBytes(hash));

            // index
            buffer.AddRange(BitConverter.GetBytes(n));

            return buffer.ToArray();
        }

        #endregion
    }
}
