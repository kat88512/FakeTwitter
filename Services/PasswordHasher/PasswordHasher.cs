using CryptoHelper;

namespace Services.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
