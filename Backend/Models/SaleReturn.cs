using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SaleReturn
    {
        public long Id { get; set; }
        public decimal? GrossSaleReturn { get; set; }
        public decimal? DiscByPercent { get; set; }
        public decimal? DiscByValue { get; set; }
        public decimal? NetSaleReturnTotal { get; set; }
        public decimal? GrandTotal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? UserId { get; set; }
        public decimal? Deduction { get; set; }
    }
}
