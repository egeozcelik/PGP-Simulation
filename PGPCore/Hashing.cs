using System.Security.Cryptography;
using System.Text;

namespace PGP
{
    public static class Hashing
    {
        public static string ComputeHash(string message)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                var hashBytes = sha256.ComputeHash(bytes);
                return ConvertBytesToHexString(hashBytes);
            }
        }

        public static bool VerifyHash(string message, string hash)
        {
            var computedHash = ComputeHash(message);
            return string.Equals(computedHash, hash);
        }

        private static string ConvertBytesToHexString(byte[] bytes)
        {
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}