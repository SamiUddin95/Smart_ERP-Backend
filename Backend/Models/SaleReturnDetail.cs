using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE_RETURN_DETAIL")]
    public partial class SaleReturnDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("SALE_RETURN_ID")]
        public long? SaleReturnId { get; set; }
        [Column("BARCODE")]
        [StringLength(20)]
        public string Barcode { get; set; }
        [Column("ITEM_NAME")]
        [StringLength(20)]
        public string ItemName { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("SALE_PRICE")]
        public decimal? SalePrice { get; set; }
        [Column("DISCOUNT")]
        public decimal? Discount { get; set; }
        [Column("NET_SALE_PRICE")]
        public decimal? NetSalePrice { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
