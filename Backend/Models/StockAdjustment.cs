using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class StockAdjustment
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public int? StockInHand { get; set; }
        public int? StockInShelf { get; set; }
        public decimal? StockInHandAmount { get; set; }
        public decimal? StockInShelfAmount { get; set; }
        public int? DifferQty { get; set; }
        public decimal? DfferQtyAmount { get; set; }
        public decimal? TotalAmountIncrease { get; set; }
        public decimal? TotalAmountDecrease { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Date { get; set; }
        public int? SerialNo { get; set; }
    }
}
