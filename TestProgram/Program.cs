// See https://aka.ms/new-console-template for more information
using GolomtEcommerce;
using GolomtEcommerce.Model;
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

        try
        {
            golomtsdk.CreateInvoice(request);
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        try
        {
            InquiryResponse res = golomtsdk.InquiryReq(new InquiryRequest("123"));
            Debug.WriteLine(JsonConvert.SerializeObject(res));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


        Console.WriteLine(request.checksum);
    }
}