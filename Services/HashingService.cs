using System;
using System.Security.Cryptography;
using System.Text;

namespace cats.Services
{
    internal static class HashingService
    {
        const int Iterations = 1 << 17;
        
        internal static string Hash(string salt, string password)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                Convert.FromBase64String(salt),
                Iterations))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(20));
            }
        }
    }
}
