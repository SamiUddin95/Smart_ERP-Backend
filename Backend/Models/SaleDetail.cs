using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE_DETAIL")]
    public partial class SaleDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("SALE_ID")]
        public long SaleId { get; set; }
        [Column("BAR_CODE")]
        public string BarCode { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(19, 2)")]
        public decimal? SalePrice { get; set; }
        [Column("DISCOUNT", TypeName = "decimal(19, 2)")]
        public decimal? Discount { get; set; }
        [Column("TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? Total { get; set; }
        [Column("NET_SALE_PRICE", TypeName = "decimal(19, 2)")]
        public decimal? NetSalePrice { get; set; }
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
        [StringLength(50)]
        public string ItemName { get; set; }
    }
}
