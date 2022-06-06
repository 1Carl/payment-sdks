using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using GolomtEcommerce.Model;

namespace GolomtEcommerce
{
    public class Golomt
    {
        Utils.Api InvoiceCreate = new Utils.Api("/api/invoice", HttpMethod.Post);
        Utils.Api Inquiry = new Utils.Api("/api/inquiry", HttpMethod.Post);
        Utils.Api PayByToken = new Utils.Api("/api/pay", HttpMethod.Post);

        string endpoint { get; set; }
        string secret { get; set; }
        string bearerToken { get; set; }

        public Golomt(string endpoint, string secret, string bearerToken)
        {
            this.endpoint = endpoint;
            this.secret = secret;
            this.bearerToken = bearerToken;
        }

        public string httpRequestGolomt(Request body, Utils.Api api)
        {
            body.computeHash(secret);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            HttpResponseMessage response;

            if (api.method == HttpMethod.Post)
            {
                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(endpoint + api.path, content).Result;
            }
            else
            {
                response = client.GetAsync(endpoint + api.path).Result;
            }

            if ((int)response.StatusCode != 200)
            {
                throw new Exception("Error: " + response.Content.ReadAsStringAsync().Result);
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public CreateInvoiceResponse CreateInvoice(AInvoice req)
        {
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

