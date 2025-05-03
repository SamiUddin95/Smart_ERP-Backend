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
        [Column("SERIAL_NO")]
        public long? SerialNo { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
        [Column("REMARKS")]
        [StringLength(500)]
        public string Remarks { get; set; }
        [Column("STATUS")]
        public bool? Status { get; set; }
        [Column("STOCK_IN_HAND")]
        public int? StockInHand { get; set; }
        [Column("STOCK_ON_SHELF")]
        public int? StockOnShelf { get; set; }
        [Column("STOCK_IN_HAND_AMOUNT")]
        public decimal? StockInHandAmount { get; set; }
        [Column("STOCK_ON_SHELF_AMOUNT")]
        public decimal? StockOnShelfAmount { get; set; }
        [Column("TOTAL_ADJUSTMENT_QTY")]
        public decimal? TotalAdjustmentQty { get; set; }
        [Column("ADJUSTMENT_AMOUNT")]
        public decimal? AdjustmentAmount { get; set; }
        [Column("PARTY_ID")]
        public int? PartyId { get; set; }
        [Column("PARTY_NAME")]
        [StringLength(150)]
        public string PartyName { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
    }
}
