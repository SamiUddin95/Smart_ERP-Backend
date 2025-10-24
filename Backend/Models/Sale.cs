using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Sale
    {
        public long Id { get; set; }
        public decimal? GrossSale { get; set; }
        public decimal? DiscountPerc { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Return { get; set; }
        public decimal? EarnedPoints { get; set; }
        public decimal? NetSaleTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? FlatDisc { get; set; }
        public int? UserId { get; set; }
        public decimal? CashReceived { get; set; }
        public decimal? CashCharged { get; set; }
        public decimal? CashBack { get; set; }
        public decimal? InvoiceBalance { get; set; }
        public string InvoiceType { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
    }
}
