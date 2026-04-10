using System.Security.Cryptography;
using System.Text;

public static class SecurityManager
{
    public static string Hash(string input)
    {
        using (var sha = SHA256.Create())
        {
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return System.Convert.ToBase64String(bytes);
        }
    }
}