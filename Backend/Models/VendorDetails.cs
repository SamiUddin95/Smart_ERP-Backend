using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class VendorDetails
    {
        public int Id { get; set; }
        public string Business { get; set; }
        public string Individual { get; set; }
        public string Salutation { get; set; }
        public string Code { get; set; }
        public string VendorName { get; set; }
        public string ContactPerson { get; set; }
        public string VendorAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? VendorBalance { get; set; }
        public string PaymentTerms { get; set; }
        public string BankDetails { get; set; }
        public string Website { get; set; }
    }
}
