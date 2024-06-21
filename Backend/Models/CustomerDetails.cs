using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class CustomerDetails
    {
        public CustomerDetails()
        {
            Invoice = new HashSet<Invoice>();
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        public string Business { get; set; }
        public string Individual { get; set; }
        public string Code { get; set; }
        public string ShopName { get; set; }
        public int? ShopNumber { get; set; }
        public string ContactPerson { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? CustomerBalance { get; set; }
        public int? PaymentTerms { get; set; }
        public string BankDetails { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string TikTok { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Website { get; set; }

        public PaymentTerms PaymentTermsNavigation { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
