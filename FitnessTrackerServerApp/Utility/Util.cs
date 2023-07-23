using System.Text;
using System.Security.Cryptography;
namespace FitnessTrackerServerApp.Utility
{
    public class Util
    {
        public static readonly string SALT_STRING = "7q3df*(&T*TKJ@*&!YTFSD*&";
        public static readonly string SECRET_KEY = "PUF3yG&%7pbh$W^q@Boi2Y$LKjHwe";
        public static readonly string JSON_STORAGE_PATH = @"";
        public Util() { }

        public static List<string> GetIntensityTypes()
        {
            var intensities = new List<string>();
            intensities.Add("Low");
            intensities.Add("Moderate");
            intensities.Add("High");
            intensities.Add("Intense");
            return intensities;
        }

        public static string GetSaltedHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(password + Util.SALT_STRING);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return hashedPassword;
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedEnteredPassword = GetSaltedHash(enteredPassword);
            return storedHash.Equals(hashedEnteredPassword);
        }
    }
}
