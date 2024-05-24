using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [Column("Invoice#")]
        [StringLength(50)]
        public string Invoice1 { get; set; }
        [Column("Customer_Name")]
        public int? CustomerName { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string DueDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? BalanceDue { get; set; }
        public int? Qty { get; set; }
        [Column("Unit_Price")]
        public decimal? UnitPrice { get; set; }
        [StringLength(50)]
        public string Particulars { get; set; }

        [ForeignKey("CustomerName")]
        [InverseProperty("Invoice")]
        public CustomerDetails CustomerNameNavigation { get; set; }
        [InverseProperty("InvoiceNoNavigation")]
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
