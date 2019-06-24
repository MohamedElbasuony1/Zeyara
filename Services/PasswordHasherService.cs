using CryptoHelper;

namespace Services
{
    public class PasswordHasherService
    {
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
