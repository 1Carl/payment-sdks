// See https://aka.ms/new-console-template for more information
using GolomtEcommerce;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

public class Test {
    public static void Main() {
        string secret = "";
        string token = "";
        var golomtsdk = new GolomtEcommerce.Golomt("https://ecommerce.golomtbank.com", secret, token);

        var request = new CreateInvoiceRequest(10.0f, "123", "POST", "http://localhost:8080/callback", true);
        request.computeHash(secret);
        var json = JsonConvert.SerializeObject(request);
        Debug.WriteLine(json);

        golomtsdk.CreateInvoice(request);
        Console.WriteLine(request.checksum);
    }
}