using BCrypt.Net;
using System.Diagnostics.SymbolStore;

namespace BookShare.Service.Commons.Security
{
    public class PasswordHasher
    {
        public static(string passwordHasher,string salt) Hash(string password)
        {
            string salt = Guid.NewGuid().ToString();
            string strongPassword = salt + password;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(strongPassword);
            return (passwordHash, salt);
        }

        public static bool Varify(string password,string salt,string passwordHash) 
        {
            string strongPassword = salt + password;
            var result = BCrypt.Net.BCrypt.Verify(strongPassword, passwordHash);
            return result;
        }
    }
}
