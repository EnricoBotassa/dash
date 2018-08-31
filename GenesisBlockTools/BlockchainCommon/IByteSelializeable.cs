using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public interface IByteSerializeable
    {
        byte[] Serialize();
    }
}
