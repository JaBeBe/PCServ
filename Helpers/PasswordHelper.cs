using System;
using System.Security.Cryptography;
using System.Text;

namespace PCServ.Helpers
{
    public static class PasswordHelper
    {
		public static string Hash(string password, string salt = "")
		{
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);

			string hash = "";

			using (SHA256Managed sha256 = new SHA256Managed())
			{
				byte[] hashBytes = sha256.ComputeHash(passwordBytes);
				foreach (byte b in hashBytes)
				{
					hash += String.Format("{0:x2}", b);
				}
			}

			return hash;
		}

		public static bool Verify(string password, string hash, string salt="")
        {
            string passwordHash = PasswordHelper.Hash(password, salt);
            return hash.Equals(passwordHash);
        }
    }
}
