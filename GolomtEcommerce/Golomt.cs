using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace GolomtEcommerce
{
    public class Golomt
    {
        Utils.Api InvoiceCreate = new Utils.Api("/api/invoice", "POST");
        Utils.Api Inquiry = new Utils.Api("/api/inquiry", "POST");
        Utils.Api PayByToken = new Utils.Api("/api/pay", "POST");

        string endpoint { get; set; }
        string secret { get; set; }
        string bearerToken { get; set; }

        public Golomt(string endpoint, string secret, string bearerToken)
        {
            this.endpoint = endpoint;
            this.secret = secret;
            this.bearerToken = bearerToken;
        }

        public string httpRequestGolomt(Object body, Utils.Api api)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(endpoint, content).Result;
            if ((int)response.StatusCode != 200)
            {
                throw new Exception("Error: " + response.Content.ReadAsStringAsync().Result);
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public CreateInvoiceResponse CreateInvoice(CreateInvoiceRequest req)
        {
            req.computeHash(secret);
            var result = httpRequestGolomt(req, InvoiceCreate);
            var res = JsonConvert.DeserializeObject<CreateInvoiceResponse>(result);
            if (res == null)
            {
                throw new Exception("Error: " + result);
            }
            return res;
        }

        public InquiryResponse InquiryReq(InquiryRequest req)
        {
            req.computeHash(secret);
            var result = httpRequestGolomt(req, Inquiry);
            var res = JsonConvert.DeserializeObject<InquiryResponse>(result);
            if (res == null)
            {
                throw new Exception("Error: " + result);
            }

            if (String.Equals(res.errorCode, "000"))
            {
                throw new Exception(res.errorDesc);
            }

            return res;
        }

        public PayByTokenResponse PayByTokenReq(PayByTokenRequest req)
        {
            req.computeHash(secret);
            var result = httpRequestGolomt(req, PayByToken);
            var res = JsonConvert.DeserializeObject<PayByTokenResponse>(result);
            if (res == null)
            {
                throw new Exception("Error: " + result);
            }
            if (String.Equals(res.errorCode, "000"))
            {
                throw new Exception(res.errorDesc);
            }
            return res;
        }

        public string GetUrlByInvoiceId(string invoice, string lang, string paymentMethod)
        {
            var url = endpoint + "/" + paymentMethod + "/" + lang + "/" + invoice;
            return url;
        }
    }

}

