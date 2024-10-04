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
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        [InverseProperty("PaymentTermsNavigation")]
        public ICollection<CustomerDetails> CustomerDetails { get; set; }
    }
}
