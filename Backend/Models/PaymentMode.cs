using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Payment_Mode")]
    public partial class PaymentMode
    {
        public PaymentMode()
        {
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        [Column("Payment_mode")]
        [StringLength(50)]
        public string PaymentMode1 { get; set; }
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

        [InverseProperty("ModeNavigation")]
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
