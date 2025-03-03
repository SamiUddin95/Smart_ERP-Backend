using Backend.Models;
using System.Collections.Generic;

namespace Backend.Model
{
    public class StockAjdModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Remarks { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Status { get; set; }
        public int? StockInHand { get; set; }
        public int? StockInShelf { get; set; }
        public decimal? StockInHandAmount { get; set; }
        public decimal? StockInShelfAmount { get; set; }
        public int? DifferQty { get; set; }
        public decimal? DfferQtyAmount { get; set; }
        public decimal? TotalAmountIncrease { get; set; }
        public decimal? TotalAmountDecrease { get; set; }

        public List<StockAdjDetail> stckAdjDtl { get; set; }

    } 
        public class stckAdjDtlModel
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
    }
}
