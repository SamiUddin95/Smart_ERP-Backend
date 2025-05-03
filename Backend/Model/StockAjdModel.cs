using Backend.Models;
using System.Collections.Generic;

namespace Backend.Model
{
    public class StockAjdModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int Location { get; set; }
        public string Remarks { get; set; }
        public string UpdatedBy { get; set; }
        public bool? Status { get; set; }
        public int? StockInHand { get; set; }
        public int? StockOnShelf { get; set; }
        public decimal? StockInHandAmount { get; set; }
        public decimal? StockOnShelfAmount { get; set; }
        public decimal? TotalAdjustmentQty { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public int? PartyId { get; set; }
        public string PartyName { get; set; }
        public List<StockAdjDetail> stckAdjDtl { get; set; }

    } 
        public class stckAdjDtlModel
        {
        public long Id { get; set; }
        public long? StckAdjId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int? StockInHand { get; set; }
        public int? StockOnShelf { get; set; }
        public int? AjustmentQty { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Total { get; set; }
    }
}
