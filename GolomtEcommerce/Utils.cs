using System.Diagnostics; 
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace GolomtEcommerce;

public class Utils
{ 
    public static string GetHMAC(string key, string text)
    {
        key = key ?? "";
        Debug.WriteLine("hash input: " + text);

        using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
        {
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToHexString(hash).ToLower();
        }
    }

    public struct Api {
        public string path;
        public HttpMethod method;

        public Api(string path, HttpMethod method) {
            this.path = path;
            this.method = method;
        }
    }
}
