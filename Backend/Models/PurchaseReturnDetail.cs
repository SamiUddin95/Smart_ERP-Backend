using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_RETURN_DETAIL")]
    public partial class PurchaseReturnDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("ORDER_RETURN_ID")]
        public long? OrderReturnId { get; set; }
        [Column("BARCODE")]
        public string Barcode { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("FULL_RATE")]
        public decimal? FullRate { get; set; }
        [Column("DISC")]
        public decimal? Disc { get; set; }
        [Column("FLAT_DISC")]
        public decimal? FlatDisc { get; set; }
        [Column("TOTAL")]
        public decimal? Total { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
    }
}
