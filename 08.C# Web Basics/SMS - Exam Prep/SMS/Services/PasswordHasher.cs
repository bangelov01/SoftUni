namespace SMS.Services
{
    using System.Security.Cryptography;
    using System.Text;

    using SMS.Contracts;

    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
