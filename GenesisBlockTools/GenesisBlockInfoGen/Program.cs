﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenesisBlockInfoGen
{
    class Program
    {
        /* EXAMPLE:

            Private-Key: (256 bit)
            priv:
                21:bf:fb:c1:97:bb:71:2f:47:a2:1c:ce:97:87:aa:
                61:88:a0:83:f6:35:10:e2:80:6e:cd:44:a0:89:15:
                0d:5d
            pub:
                04:dd:18:b6:b6:3d:79:d4:2a:4d:c8:f9:19:63:ab:
                50:f5:27:1b:9b:ae:62:02:78:bb:fa:8b:c8:cd:52:
                3c:3a:f3:58:4e:43:c8:df:0b:b9:9d:89:dd:d3:1e:
                e6:f6:e5:33:b0:8e:bd:d3:a3:d2:40:44:07:dd:c5:
                6d:f2:f6:2f:ce
            ASN1 OID: prime256v1
            NIST CURVE: P-256
            -----BEGIN EC PRIVATE KEY-----
            MHcCAQEEICG/+8GXu3EvR6IczpeHqmGIoIP2NRDigG7NRKCJFQ1doAoGCCqGSM49
            AwEHoUQDQgAE3Ri2tj151CpNyPkZY6tQ9Scbm65iAni7+ovIzVI8OvNYTkPI3wu5
            nYnd0x7m9uUzsI6906PSQEQH3cVt8vYvzg==
            -----END EC PRIVATE KEY-----

        */

        static void Main(string[] args)
        {
            
            string msg = "StackOverflow test 123";
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetByteCount(msg));

            var keyPair = DashEC.SecP256r1KeyPairGen();

            Console.WriteLine("################################ ZALGOCOIN MAIN CHAIN ##################################");
            Console.WriteLine("################################# HASH FUNCTION TEST ###################################");
            string contStr = "The quick brown fox jumps over the lazy dog";
            var inputBytes = Encoding.UTF8.GetBytes(contStr);
            var outputBytes = Utilities.Hash(inputBytes);
            var outputHex = Utilities.ToSolidHex(outputBytes);
            Console.WriteLine($" Input string: {contStr}");
            Console.WriteLine($" X11 hashe: {outputHex}");

            Console.WriteLine("################################ GENESIS BLOCK MAINER ##################################");
            BlockSolver s = new BlockSolver(
                "048C5702648E9C7FF4FB64AFFAE1E3CE7150BB73FD66232AF229EC29EA8D2568817870C1E24E2BF58410DCD72BA7B3FC1AAAB2B88E58B2D595405A0D5AAE8B03E8",
                //keyPair.PubKeyByteHexStr, // pubkey
                "It's ZalgoCoin time! He comes. 01/10/2018", // timestamp
                1535788800, // timestamp bits
                0, // nBits
                0, // nTime
                0, // nNonce
                1); // threads

            var res = s.Solve();


            Console.ReadKey();
        }
    }
}
