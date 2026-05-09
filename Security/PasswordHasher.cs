using System.Security.Cryptography;

namespace TesteDevAEC.Security
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public static (byte[] salt, byte[] hash) Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: KeySize);

            return (salt, hash);
        }

        public static bool Verify(string password, byte[] salt, byte[] expectedHash)
        {
            var actualHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}