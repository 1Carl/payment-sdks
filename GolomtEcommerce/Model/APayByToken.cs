using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolomtEcommerce.Model
{
    public abstract class APayByToken : Request
    {
        public abstract string amount { get; set; }
        public abstract string invoice { get; set; }
        public abstract string transactionId { get; set; }
        public abstract string token { get; set; }
        public abstract string lang { get; set; }
        public APayByToken(string transactionId, string token, string invoice, float amount, string lang)
        {
            this.transactionId = transactionId;
            this.token = token;
            this.invoice = invoice;
            this.amount = amount.ToString("n2");
            this.lang = lang;
        }
        public override void computeHash(string secret)
        {
            this.computeHash(secret, amount + transactionId + token);
        }
    }
}

