using System.Security.Cryptography;

namespace DocumentService.Data
{
    public class GenerateRandomId
    {
        public string Generate(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
