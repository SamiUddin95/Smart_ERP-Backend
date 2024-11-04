using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("COUNTER_SALE_DETAIL")]
    public partial class CounterSaleDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("COUNTER_SALE_ID")]
        public long CounterSaleId { get; set; }
        [Column("BAR_CODE")]
        public string BarCode { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Column("QUANTITY")]
        public int? Quantity { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(19, 2)")]
        public decimal? SalePrice { get; set; }
        [Column("DISCOUNT", TypeName = "decimal(19, 2)")]
        public decimal? Discount { get; set; }
        [Column("TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? Total { get; set; }
        [Column("NET_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? NetTotal { get; set; }
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
