using BC = BCrypt.Net.BCrypt;

namespace Healthware.Core.Security
{
    public class PasswordEncryptionDecryption
    {
        public static string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string newPassword, string oldPassword)
        {
            return oldPassword != null && BC.Verify(newPassword, oldPassword);
        }
        private static string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

    }
}
