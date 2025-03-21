using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("STOCK_ADJUSTMENT")]
    public partial class StockAdjustment
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("LOCATION")]
        [StringLength(100)]
        public string Location { get; set; }
        [Column("REMARKS")]
        [StringLength(500)]
        public string Remarks { get; set; }
        [Column("STATUS")]
        public bool? Status { get; set; }
        [Column("STOCK_IN_HAND")]
        public int? StockInHand { get; set; }
        [Column("STOCK_IN_SHELF")]
        public int? StockInShelf { get; set; }
        [Column("STOCK_IN_HAND_AMOUNT")]
        public decimal? StockInHandAmount { get; set; }
        [Column("STOCK_IN_SHELF_AMOUNT")]
        public decimal? StockInShelfAmount { get; set; }
        [Column("DIFFER_QTY")]
        public int? DifferQty { get; set; }
        [Column("DFFER_QTY_AMOUNT")]
        public decimal? DfferQtyAmount { get; set; }
        [Column("TOTAL_AMOUNT_INCREASE")]
        public decimal? TotalAmountIncrease { get; set; }
        [Column("TOTAL_AMOUNT_DECREASE")]
        public decimal? TotalAmountDecrease { get; set; }
        [Column("CREATED_AT")]
        [StringLength(100)]
        public string CreatedAt { get; set; }
        [Column("UPDATED_AT")]
        [StringLength(100)]
        public string UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column("DATE")]
        [StringLength(100)]
        public string Date { get; set; }
        [Column("SERIAL_NO")]
        public int? SerialNo { get; set; }
    }
}
