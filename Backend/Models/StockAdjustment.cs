using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class StockAdjustment
    {
        public long Id { get; set; }
        public long? SerialNo { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public int? StockInHand { get; set; }
        public int? StockOnShelf { get; set; }
        public decimal? StockInHandAmount { get; set; }
        public decimal? StockOnShelfAmount { get; set; }
        public decimal? TotalAdjustmentQty { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public int? PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
