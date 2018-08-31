using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisBlockInfoGen
{
    public class TxIn : IByteSerializeable
    {
        public OutPoint prevout { get; set; }
        public Script scriptSig { get; set; }
        public uint nSequence { get; set; }

        public TxIn()
        {
            nSequence = uint.MaxValue;
            scriptSig = new Script();
            prevout = new OutPoint();
        }

        public TxIn(OutPoint prevoutIn) : this()
        {
            prevout = prevoutIn;
        }

        public TxIn(OutPoint prevoutIn, Script scriptSigIn) : this(prevoutIn)
        {
            scriptSig = scriptSigIn;
        }

        public TxIn(OutPoint prevoutIn, Script scriptSigIn, uint nSequenceId) : this(prevoutIn, scriptSigIn)
        {
            nSequence = nSequenceId;
        }

        #region IByteSerializeable implementation

        public byte[] Serialize()
        {
            List<byte> buffer = new List<byte>();

            // Outpoint
            buffer.AddRange(prevout.Serialize());
            Debug.Assert(buffer.Count == 36, "outpoint should be 36 bytes");

            // Signature Script
            buffer.AddRange(scriptSig.Serialize());
            Debug.Assert(buffer.Count >= 37, "scriptsig shoudl be at least one byte long");

            // Sequence
            buffer.AddRange(BitConverter.GetBytes(nSequence));

            return buffer.ToArray();
        }


        #endregion
    }

    public class TxOut : IByteSerializeable
    {
        public Int64 nValue { get; set; }
        public Script scriptPubKey { get; set; }

        public TxOut()
        {
            nValue = -1;
            scriptPubKey = new Script();
        }

        public TxOut(Int64 nValueIn) : this()
        {
            nValue = nValueIn;
        }

        public TxOut(Int64 nValueIn, Script scriptPubKeyIn) : this(nValueIn)
        {
            scriptPubKey = scriptPubKeyIn;
        }

        #region IByteSerializeable implementation
        public byte[] Serialize()
        {
            List<byte> buffer = new List<byte>();

            // value int64 (8 byte)
            buffer.AddRange(BitConverter.GetBytes(nValue));
            Debug.Assert(buffer.Count == 8, "tx value is not 8 bytes");

            // public key script (1 + n)
            buffer.AddRange(scriptPubKey.Serialize());
            Debug.Assert(buffer.Count >= 9, "pk script is not long enough");

            return buffer.ToArray();
        }
        #endregion
    }

    public class Transaction : IByteSerializeable
    {
        public const int CURRENT_VERSION = 1;

        public Int64 nMinTxFee { get; set; }
        public Int64 nMinRelayTxFee { get; set; }
        public int nVersion { get; set; }
        public List<TxIn> vin { get; set; }
        public List<TxOut> vout { get; set; }
        public uint nLockTime { get; set; }

        public Transaction()
        {
            nVersion = CURRENT_VERSION;
            vin = new List<TxIn>();
            vout = new List<TxOut>();
            nLockTime = 0;
        }

        #region IByteSerializeable implementation

        public byte[] Serialize()
        {
            List<byte> buffer = new List<byte>();

            // Version
            buffer.AddRange(BitConverter.GetBytes(nVersion));
            Debug.Assert(buffer.Count == 4, "tx version not 4 bytes");

            // TX IN
            buffer.AddRange(Utilities.GetVarIntBytes(vin.Count)); // Var length int
            foreach (TxIn t in vin)
            {
                buffer.AddRange(t.Serialize());
            }

            // TX OUT
            buffer.AddRange(Utilities.GetVarIntBytes(vout.Count)); // Var length int
            foreach (TxOut t in vout)
            {
                buffer.AddRange(t.Serialize());
            }

            // Locktime
            buffer.AddRange(BitConverter.GetBytes(nLockTime));

            return buffer.ToArray();
        }

        #endregion

        public byte[] GetHash()
        {
            return Utilities.Hash(Serialize());
        }
    }
}
