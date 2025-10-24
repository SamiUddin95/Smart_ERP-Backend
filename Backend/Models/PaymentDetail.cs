using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PaymentDetail
    {
        public long Id { get; set; }
        public long? SaleId { get; set; }
        public decimal? CashCharged { get; set; }
        public decimal? CashReceived { get; set; }
        public decimal? CashBack { get; set; }
        public decimal? NetTotal { get; set; }
        public decimal? InvoiceBalance { get; set; }
        public string AmountWords { get; set; }
        public string InvType { get; set; }
        public decimal? ExtraCharges { get; set; }
        public decimal? ExtraChargesPer { get; set; }
        public string MachineName { get; set; }
        public decimal? CreditAmount { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public decimal? FinalAmount { get; set; }
        public decimal? RemainingCreditAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? LocationId { get; set; }
    }
}
