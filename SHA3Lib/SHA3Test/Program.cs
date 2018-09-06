using SHA3Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHA3Test
{
    class Program
    {
        public static string ToSolidHex(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }

        static void Main(string[] args)
        {
            string contStr = "The quick brown fox jumps over the lazy dog";
            var inputBytes = Encoding.UTF8.GetBytes(contStr);

            var output = SHA3Lib.CalcX11(inputBytes);
            var hexStr = ToSolidHex(output);

            Console.WriteLine($" Input string: {contStr}");
            Console.WriteLine($" HEX result string ({output.Length} bytes): {hexStr}");

            Console.ReadLine();
        }
    }
}
