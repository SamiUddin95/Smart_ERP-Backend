using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PaymentTerms
    {
        public PaymentTerms()
        {
            CustomerDetails = new HashSet<CustomerDetails>();
        }

        public int Id { get; set; }
        public string PaymentTerms1 { get; set; }

        public ICollection<CustomerDetails> CustomerDetails { get; set; }
    }
}
