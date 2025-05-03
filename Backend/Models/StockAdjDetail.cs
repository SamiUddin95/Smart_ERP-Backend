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
        public string Location { get; set; }
        public string Batch { get; set; }
        public string Expiry { get; set; }
        public int? StockInHand { get; set; }
        public int? StockInShelf { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Total { get; set; }
        public int? AdjustmentQty { get; set; }
    }
}
