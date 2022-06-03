// See https://aka.ms/new-console-template for more information
using GolomtEcommerce;

public class Test {
    public static void Main() {
        var golomtsdk = new GolomtEcommerce.Golomt();
        var request = new CreateInvoiceRequest(10.0f, "123", "POST", "http://localhost:8080/callback", true);
        request.computeHash("secret");
        Console.WriteLine(request.checksum);
    }
}