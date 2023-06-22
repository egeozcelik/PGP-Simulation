using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PGP
{
    public static class AESEncryption
    {
        public static byte[] EncryptText(string plainText, byte[] symmetricKey)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = symmetricKey;
                aes.Mode = CipherMode.ECB;

                using (var encryptor = aes.CreateEncryptor())
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    var plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public static string DecryptText(byte[] encryptedText, byte[] symmetricKey)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = symmetricKey;
                aes.Mode = CipherMode.ECB;

                using (var decryptor = aes.CreateDecryptor())
                using (var memoryStream = new MemoryStream(encryptedText))
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}