using System.Security.Cryptography;
using System.Text;

namespace Infraestructure.Security
{
    /// <summary>
    /// Provides security-related utility methods.
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Computes the SHA-256 hash of the specified string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA-256 hash of the input string.</returns>
        public static string GetSHA256(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.AppendFormat("{0:x2}", b);
            }

            return sb.ToString();
        }
    }
}