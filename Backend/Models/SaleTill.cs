using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SaleTill
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string TillOpenDateTime { get; set; }
        public string TillCloseDateTime { get; set; }
        public decimal? TillOpenAmount { get; set; }
        public decimal? TillCloseAmount { get; set; }
        public decimal? CashSale { get; set; }
        public decimal? CreditSale { get; set; }
        public decimal? NetSale { get; set; }
        public decimal? Difference { get; set; }
        public string ExcessShort { get; set; }
        public string TillNo { get; set; }
        public string TillName { get; set; }
        public string Notes { get; set; }
        public int? SaleTillId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
    }
}
