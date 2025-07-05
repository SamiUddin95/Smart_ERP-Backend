using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Vendor_Details")]
    public partial class VendorDetails
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Business { get; set; }
        [StringLength(50)]
        public string Individual { get; set; }
        [StringLength(50)]
        public string Salutation { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [Column("Vendor_Name")]
        [StringLength(50)]
        public string VendorName { get; set; }
        [Column("Contact_Person")]
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Column("Vendor_Address")]
        [StringLength(50)]
        public string VendorAddress { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("Vendor_Balance")]
        public decimal? VendorBalance { get; set; }
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string PaymentTerms { get; set; }
        [Column("Bank_Details")]
        [StringLength(50)]
        public string BankDetails { get; set; }
        [StringLength(50)]
        public string Website { get; set; }
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
    }
}
