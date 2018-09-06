using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHA3Import
{
    unsafe delegate void HashFun(byte* input, byte* output, int in_size);

    /// <summary>
    /// SHA3Lib hash functions implementation class
    /// </summary>
    public static class SHA3Lib
    {
        private static unsafe byte[] GetHash(HashFun fun, byte[] input)
        {
            var output = new byte[64];
            fixed (byte* inBuf = input)
            {
                fixed (byte* outBuf = output)
                {
                    fun(inBuf, outBuf, input.Length);
                    for (int i = 0; i < output.Length; i++)
                        output[i] = outBuf[i];
                }
            }
            return output;
        }

        // X11 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void xcoin_hash(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcX11(byte[] input)
        {
            return GetHash(xcoin_hash, input);
        }

        // Blake 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void blake512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcBlake512(byte[] input)
        {
            return GetHash(blake512, input);
        }

        // Blue Midnight Wish 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void bmw512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcBMW512(byte[] input)
        {
            return GetHash(bmw512, input);
        }

        // Groestl 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void groestl512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcGroestl512(byte[] input)
        {
            return GetHash(groestl512, input);
        }

        // Skein 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void skein512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcSkein512(byte[] input)
        {
            return GetHash(skein512, input);
        }

        // JH 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void jh512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcJH512(byte[] input)
        {
            return GetHash(jh512, input);
        }

        // Keccak 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void keccak512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcKeccak512(byte[] input)
        {
            return GetHash(keccak512, input);
        }

        // Luffa 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void luffa512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcLuffa512(byte[] input)
        {
            return GetHash(luffa512, input);
        }

        // CubeHash 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void cubehash512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcCubeHash512(byte[] input)
        {
            return GetHash(cubehash512, input);
        }

        // SHAvite-3 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void shavite512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcShavite512(byte[] input)
        {
            return GetHash(shavite512, input);
        }

        // Simd 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void simd512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcSimd512(byte[] input)
        {
            return GetHash(simd512, input);
        }

        // Echo 512
        [DllImport("SHA3Lib.dll", SetLastError = true)]
        internal static unsafe extern void echo512(byte* input, byte* output, int in_size);
        public static unsafe byte[] CalcEcho512(byte[] input)
        {
            return GetHash(echo512, input);
        }
    }
}
