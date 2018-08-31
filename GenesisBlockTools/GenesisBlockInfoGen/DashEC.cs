using System;
using System.Text;
using System.Security.Cryptography;

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;

namespace GenesisBlockInfoGen
{
    public class KeyPairEC
    {
        public byte[] PrivKey;
        public byte[] PubKey;
        public string PrivKeyByteHexStr;
        public string PubKeyByteHexStr;
    }

    public static class DashEC
    {
        private static string ToHex(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", ":");
        }

        private static string ToSolidHex(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }

        public static KeyPairEC SecP256r1KeyPairGen()
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

            string privKey = ToSolidHex(privKeyBytes);
            string pubKey = ToSolidHex(pubKeyBytes);

            Console.WriteLine($"Curve: {curve}");
            Console.WriteLine($"Generated private key ({privKeyBytes.Length} bytes):");
            Console.WriteLine($"{ToHex(privKeyBytes)}");
            Console.WriteLine($"Generated public key ({pubKeyBytes.Length} bytes):");
            Console.WriteLine($"{ToHex(pubKeyBytes)}");
            Console.WriteLine("=====================================");
            Console.WriteLine($"priv:");
            Console.WriteLine($"{privKey}");
            Console.WriteLine($"pub:");
            Console.WriteLine($"{pubKey}");

            return new KeyPairEC()
            {
                PrivKey = privKeyBytes,
                PubKey = pubKeyBytes,
                PrivKeyByteHexStr = privKey,
                PubKeyByteHexStr = pubKey
            };
        }
    }
}
