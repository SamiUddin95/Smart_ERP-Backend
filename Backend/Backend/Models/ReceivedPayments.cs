using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ReceivedPayments
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string ReceiptNo { get; set; }
        public string PaymentNo { get; set; }
        public int? Type { get; set; }
        public int? ReferenceNumber { get; set; }
        public int? CustomerName { get; set; }
        public int? InvoiceNo { get; set; }
        public int? Mode { get; set; }
        public decimal? Amount { get; set; }
        public byte[] UnusedAmount { get; set; }

        public CustomerDetails CustomerNameNavigation { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
        public PaymentMode ModeNavigation { get; set; }
        public PaymentType TypeNavigation { get; set; }
    }
}
