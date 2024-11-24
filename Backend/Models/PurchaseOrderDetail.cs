using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_ORDER_DETAIL")]
    public partial class PurchaseOrderDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("ORDER_ID")]
        public long? OrderId { get; set; }
        [Column("BAR_CODE")]
        [StringLength(50)]
        public string BarCode { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Column("SOLD_QTY")]
        public int? SoldQty { get; set; }
        [Column("RTN_QTY")]
        public int? RtnQty { get; set; }
        [Column("NET_SALE_QTY")]
        public int? NetSaleQty { get; set; }
        [Column("RATE")]
        public decimal? Rate { get; set; }
        [Column("CURRENT_STOCK")]
        public int? CurrentStock { get; set; }
        [Column("REQUIRED_QTY")]
        public decimal? RequiredQty { get; set; }
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
        [Column("ITEM_NAME")]
        [StringLength(100)]
        public string ItemName { get; set; }
    }
}
