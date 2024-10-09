using System.Security.Cryptography;

public static class SecurityUtils
{
    public static string GenerateSecureKey(int size = 32) // Size in bytes
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] key = new byte[size];
            rng.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}
