using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Pkcs;
using HashLib;

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

        static void SecP256r1_Test()
        {
            string curve = "secp256r1";
            X9ECParameters ecParams = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName(curve);
            ECDomainParameters domainParameters = new ECDomainParameters(ecParams.Curve,
                                                                         ecParams.G, ecParams.N, ecParams.H,
                                                                         ecParams.GetSeed());
            ECKeyGenerationParameters keyGenParams =
              new ECKeyGenerationParameters(domainParameters, new SecureRandom());

            AsymmetricCipherKeyPair keyPair;
            ECKeyPairGenerator generator = new ECKeyPairGenerator();
            generator.Init(keyGenParams);
            keyPair = generator.GenerateKeyPair();

            ECPrivateKeyParameters privateKey = (ECPrivateKeyParameters)keyPair.Private;
            ECPublicKeyParameters publicKey = (ECPublicKeyParameters)keyPair.Public;

            var privKeyBytes = privateKey.D.ToByteArrayUnsigned();
            var pubKeyBytes = publicKey.Q.GetEncoded();

            string privKey = Utilities.ToSolidHex(privKeyBytes);
            string pubKey = Utilities.ToSolidHex(pubKeyBytes);

            Console.WriteLine($"Curve: {curve}");
            Console.WriteLine($"Generated private key ({privKeyBytes.Length} bytes):");
            Console.WriteLine($"{Utilities.ToHex(privKeyBytes)}");
            Console.WriteLine($"Generated public key ({pubKeyBytes.Length} bytes):");
            Console.WriteLine($"{Utilities.ToHex(pubKeyBytes)}");
            Console.WriteLine("=====================================");
            Console.WriteLine($"priv:");
            Console.WriteLine($"{Utilities.ToSolidHex(privKeyBytes)}");
            Console.WriteLine($"pub:");
            Console.WriteLine($"{Utilities.ToSolidHex(pubKeyBytes)}");

        }

        static void Main(string[] args)
        {
            /*
            string msg = "StackOverflow test 123";
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetByteCount(msg));

            DashEC.FullSignatureTest(hash);*/
            //SecP256r1_Test();
            //Console.ReadKey();

            string inputStr = "Fucking in the bushes";

            var rnd = new Random();
            var input = Encoding.UTF8.GetBytes(inputStr);

            Console.WriteLine($"InputLine ({input.Length} bytes):");
            Console.WriteLine($"    {Encoding.UTF8.GetString(input)}");

            var hashFuncs = new List<IHash>();
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateBlake512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateBlueMidnightWish512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateGroestl512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateSkein512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateJH512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateKeccak512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateLuffa512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateCubeHash512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateSHAvite3_512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateSIMD512());
            hashFuncs.Add(HashFactory.Crypto.SHA3.CreateEcho512());

            foreach(var hashFunc in hashFuncs)
            {
                Console.WriteLine($"Aplied {hashFunc.Name} hash function:");
                var transform = hashFunc.ComputeBytes(input);
                input = transform.GetBytes();
                Console.WriteLine($"    {Utilities.ToSolidHex(input)}");
            }

            Console.ReadKey();
        }
    }
}
