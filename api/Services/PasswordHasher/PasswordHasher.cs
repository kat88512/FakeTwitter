using api.Models;
using api.Shared.Extensions;
using CryptoHelper;

namespace api.Services.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password).Truncate(User.PasswordHashMaxLength);
        }

        public bool VerifyPassword(string hash, string password)
        {
            var truncatedHash = hash.Truncate(User.PasswordHashMaxLength);

            return Crypto.VerifyHashedPassword(truncatedHash, password);
        }
    }
}
