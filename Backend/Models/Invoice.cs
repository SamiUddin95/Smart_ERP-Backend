using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        public string Date { get; set; }
        public string Invoice1 { get; set; }
        public int? CustomerName { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? BalanceDue { get; set; }
        public int? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Particulars { get; set; }

        public CustomerDetails CustomerNameNavigation { get; set; }
        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
