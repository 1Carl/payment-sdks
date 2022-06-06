using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolomtEcommerce.Model
{
    public abstract class AInvoice : Request
    {
        public abstract string amount { get; set; }
        public abstract string transactionId { get; set; }
        public abstract string returnType { get; set; }
        public abstract string callback { get; set; }
        public abstract bool getToken { get; set; }

        public AInvoice(float amount, string transactionId, string returnType, string callback, bool getToken)
        {
            this.amount = amount.ToString("n2");
            this.transactionId = transactionId;
            this.callback = callback;
            this.getToken = getToken;
            this.returnType = returnType;
        }
        public override void computeHash(string secret)
        {
            this.computeHash(secret, transactionId + amount + returnType + callback);
        }
    }
}
