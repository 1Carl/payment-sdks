// See https://aka.ms/new-console-template for more information
using GolomtEcommerse;

public class Test {
    public static void Main() {
        var golomtsdk = new GolomtEcommerse.Golomt();
        var request = new CreateInvoiceRequest(10.0f, "123", "POST", "http://localhost:8080/callback", true);
        request.computeHash("secret");
        Console.WriteLine(request.checksum);
    }
}