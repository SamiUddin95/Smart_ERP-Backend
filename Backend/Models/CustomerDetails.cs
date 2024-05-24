using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Customer_Details")]
    public partial class CustomerDetails
    {
        public CustomerDetails()
        {
            Invoice = new HashSet<Invoice>();
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Business { get; set; }
        [StringLength(50)]
        public string Individual { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [Column("Shop_Name")]
        [StringLength(50)]
        public string ShopName { get; set; }
        [Column("Shop_Number")]
        public int? ShopNumber { get; set; }
        [Column("Contact_Person")]
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Column("Bill_To")]
        [StringLength(50)]
        public string BillTo { get; set; }
        [Column("Ship_To")]
        [StringLength(50)]
        public string ShipTo { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("Customer_Balance")]
        public decimal? CustomerBalance { get; set; }
        [Column("Payment_Terms")]
        public int? PaymentTerms { get; set; }
        [Column("Bank_Details")]
        [StringLength(50)]
        public string BankDetails { get; set; }
        [StringLength(50)]
        public string Facebook { get; set; }
        [StringLength(50)]
        public string Instagram { get; set; }
        [StringLength(50)]
        public string TikTok { get; set; }
        [StringLength(50)]
        public string Linkedin { get; set; }
        [StringLength(50)]
        public string Twitter { get; set; }
        [StringLength(50)]
        public string Website { get; set; }

        [ForeignKey("PaymentTerms")]
        [InverseProperty("CustomerDetails")]
        public PaymentTerms PaymentTermsNavigation { get; set; }
        [InverseProperty("CustomerNameNavigation")]
        public ICollection<Invoice> Invoice { get; set; }
        [InverseProperty("CustomerNameNavigation")]
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
