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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<CustomerDetails> CustomerDetails { get; set; }
    }
}
