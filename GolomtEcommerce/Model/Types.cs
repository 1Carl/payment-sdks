
namespace GolomtEcommerce.Model
{
    public class CreateInvoiceRequest : AInvoice
    {
        public override string amount { get; set; }
        public override string transactionId { get; set; }
        // POST GET MOBILE
        public override string returnType { get; set; }
        public override string callback { get; set; }
        public override bool getToken { get; set; }

        public CreateInvoiceRequest(float amount, string transactionId, string returnType, string callback, bool getToken) : base(amount, transactionId, returnType, callback, getToken)
        {
        }
    }

    public class InquiryRequest : AInquiry
    {
        public override string transactionId { get; set; }

        public InquiryRequest(string transactionId) : base(transactionId)
        {
        }
    }

    public class PayByTokenRequest : APayByToken
    {
        public override string amount { get; set; }
        public override string invoice { get; set; }
        public override string transactionId { get; set; }
        public override string token { get; set; }
        public override string lang { get; set; }

        public PayByTokenRequest(string transactionId, string token, string invoice, float amount, string lang) : base(transactionId, token, invoice, amount, lang)
        {
        }
    }

    public class ResponseType
    {
        public string errorDesc { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
    }

    public class PayByTokenResponse : ResponseType
    {
        public string amount { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string cardNumber { get; set; } = string.Empty;
    }

    public class InquiryResponse : ResponseType
    {
        public string amount { get; set; } = string.Empty;
        public string bank { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string cardHolder { get; set; } = string.Empty;
        public string cardNumber { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }

    public class CreateInvoiceResponse
    {
        public string invoice { get; set; } = string.Empty;
        public string checksum { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string timestamp { get; set; } = string.Empty;
        public int status { get; set; }
        public string error { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;

    }
}