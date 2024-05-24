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

        [InverseProperty("ModeNavigation")]
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
