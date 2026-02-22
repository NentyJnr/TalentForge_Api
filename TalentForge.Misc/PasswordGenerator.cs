
using System.Security.Cryptography;

namespace TalentForge.Misc
{
    public class PasswordGenerator
    {
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string Symbols = "!@#$%^&*()_-+=<>?";

        public string GenerateRandomPassword(int length = 8)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 characters");

            var allChars = LowerCase + UpperCase + Digits + Symbols;
            var password = new char[length];

            using var rng = RandomNumberGenerator.Create();
            var randomBytes = new byte[length];
            rng.GetBytes(randomBytes);

            // Ensure at least one character from each category
            password[0] = LowerCase[randomBytes[0] % LowerCase.Length];
            password[1] = UpperCase[randomBytes[1] % UpperCase.Length];
            password[2] = Digits[randomBytes[2] % Digits.Length];
            password[3] = Symbols[randomBytes[3] % Symbols.Length];

            // Fill remaining characters randomly
            for (int i = 4; i < length; i++)
            {
                password[i] = allChars[randomBytes[i] % allChars.Length];
            }

            // Shuffle the password
            Shuffle(password, rng);

            return new string(password);
        }

        private static void Shuffle(char[] array, RandomNumberGenerator rng)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                var randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                int j = BitConverter.ToInt32(randomBytes, 0) % (i + 1);
                if (j < 0) j = -j;

                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}
