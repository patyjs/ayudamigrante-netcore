using System;
using System.Security.Cryptography;
using System.Text;

namespace Codebehind
{
    public class Security
    {
        public static string SHA256Hash(string s)
        {
            StringBuilder sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(s));

                foreach (Byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

    }
}