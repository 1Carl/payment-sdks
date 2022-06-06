using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolomtEcommerce.Model
{
    public abstract class AInquiry : Request
    {
        public abstract string transactionId { get; set; }

        protected AInquiry(string transactionId)
        {
            this.transactionId = transactionId;
        }
        public override void computeHash(string secret)
        {
            this.computeHash(secret, transactionId + transactionId);
        }
    }
}
