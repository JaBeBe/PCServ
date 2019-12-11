using System;
using System.Security.Cryptography;
using System.Text;

namespace PCServ.Helpers
{
    public static class PasswordHelper
    {
        public static string Hash(string password, string salt = "")
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password+salt);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }

            return Encoding.Default.GetString(hashBytes);
        }

        public static bool Verify(string password, string hash, string salt="")
        {
            string passwordHash = PasswordHelper.Hash(password, salt);
            return hash.Equals(passwordHash);
        }
    }
}
