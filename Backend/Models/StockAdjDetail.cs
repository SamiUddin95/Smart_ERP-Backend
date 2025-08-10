using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class StockAdjDetail
    {
        public long Id { get; set; }
        public long? StckAdjId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int? StockInHand { get; set; }
        public int? StockOnShelf { get; set; }
        public int? AdjustmentQty { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Total { get; set; }
    }
}
