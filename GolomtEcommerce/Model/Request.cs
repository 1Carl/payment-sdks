using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolomtEcommerce.Model
{
    public abstract class Request
    {
        public string checksum { get; set; } = string.Empty;

        protected void computeHash(string secret, string data)
        {
            this.checksum = Utils.GetHMAC(secret, data);
        }

        public abstract void computeHash(string secret);
    }
}
