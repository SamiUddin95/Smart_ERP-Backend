using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("STOCK_ADJ_DETAIL")]
    public partial class StockAdjDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("STCK_ADJ_ID")]
        public long? StckAdjId { get; set; }
        [Column("BAR_CODE")]
        [StringLength(100)]
        public string BarCode { get; set; }
        [Column("ITEM_NAME")]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Column("STOCK_IN_HAND")]
        public int? StockInHand { get; set; }
        [Column("STOCK_ON_SHELF")]
        public int? StockOnShelf { get; set; }
        [Column("ADJUSTMENT_QTY")]
        public int? AdjustmentQty { get; set; }
        [Column("PURCHASE_PRICE")]
        public decimal? PurchasePrice { get; set; }
        [Column("SALE_PRICE")]
        public decimal? SalePrice { get; set; }
        [Column("TOTAL")]
        public decimal? Total { get; set; }
    }
}
