using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Received_Payments")]
    public partial class ReceivedPayments
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [StringLength(50)]
        public string ReceiptNo { get; set; }
        [StringLength(50)]
        public string PaymentNo { get; set; }
        public int? Type { get; set; }
        [Column("Reference_Number")]
        public int? ReferenceNumber { get; set; }
        [Column("Customer_Name")]
        public int? CustomerName { get; set; }
        public int? InvoiceNo { get; set; }
        public int? Mode { get; set; }
        public decimal? Amount { get; set; }
        [Column("Unused_Amount")]
        [MaxLength(50)]
        public byte[] UnusedAmount { get; set; }
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

        [ForeignKey("CustomerName")]
        [InverseProperty("ReceivedPayments")]
        public CustomerDetails CustomerNameNavigation { get; set; }
        [ForeignKey("InvoiceNo")]
        [InverseProperty("ReceivedPayments")]
        public Invoice InvoiceNoNavigation { get; set; }
        [ForeignKey("Mode")]
        [InverseProperty("ReceivedPayments")]
        public PaymentMode ModeNavigation { get; set; }
        [ForeignKey("Type")]
        [InverseProperty("ReceivedPayments")]
        public PaymentType TypeNavigation { get; set; }
    }
}
