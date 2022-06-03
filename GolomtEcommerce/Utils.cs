using System.Security.Cryptography;
using System.Text;

namespace GolomtEcommerce;

public class Utils
{
    public static string GetHMAC(string key, string text)
    {
        key = key ?? "";

        using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
        {
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(hash);
        }
    }

    public struct Api {
        public string url;
        public string method;

        public Api(string url, string method) {
            this.url = url;
            this.method = method;
        }
    }
}
