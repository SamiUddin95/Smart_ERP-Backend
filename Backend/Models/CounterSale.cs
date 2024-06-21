using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class CounterSale
    {
        public long Id { get; set; }
        public decimal? GrossSale { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FlatDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? Misc { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Return { get; set; }
        public decimal? EarnedPoints { get; set; }
        public decimal? NetAmount { get; set; }
    }
}
