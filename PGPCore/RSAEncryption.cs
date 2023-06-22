using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;
using System.IO;

namespace PGP
{
    public static class KeyGenerator
    {
        public static byte[] GenerateSymmetricKey()
        {
            var keyGenerator = GeneratorUtilities.GetKeyGenerator("AES");
            keyGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 256)); // 256-bit 

            return keyGenerator.GenerateKey();
        }

        public static AsymmetricCipherKeyPair GenerateRSAKeyPair()
        {
            var rsaKeyPairGenerator = new RsaKeyPairGenerator();
            rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));

            return rsaKeyPairGenerator.GenerateKeyPair();
        }

        public static void SavePrivateKey(AsymmetricKeyParameter privateKey, string fileName)
        {
            using (var privateKeyStream = new StreamWriter(fileName))
            {
                var pemWriter = new PemWriter(privateKeyStream);
                pemWriter.WriteObject(privateKey);
                pemWriter.Writer.Flush();
            }
        }

        public static void SavePublicKey(AsymmetricKeyParameter publicKey, string fileName)
        {
            using (var publicKeyStream = new StreamWriter(fileName))
            {
                var pemWriter = new PemWriter(publicKeyStream);
                pemWriter.WriteObject(publicKey);
                pemWriter.Writer.Flush();
            }
        }

        public static string GetPrivateKey(AsymmetricCipherKeyPair keyPair)
        {
            using (var stringWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(stringWriter);
                pemWriter.WriteObject(keyPair.Private);
                pemWriter.Writer.Flush();
                return stringWriter.ToString();
            }
        }

        public static string GetPublicKey(AsymmetricCipherKeyPair keyPair)
        {
            using (var stringWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(stringWriter);
                pemWriter.WriteObject(keyPair.Public);
                pemWriter.Writer.Flush();
                return stringWriter.ToString();
            }
        }
    }
}
