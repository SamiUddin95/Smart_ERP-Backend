using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Payment_terms")]
    public partial class PaymentTerms
    {
        public PaymentTerms()
        {
            CustomerDetails = new HashSet<CustomerDetails>();
        }

        public int Id { get; set; }
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string PaymentTerms1 { get; set; }

        [InverseProperty("PaymentTermsNavigation")]
        public ICollection<CustomerDetails> CustomerDetails { get; set; }
    }
}
