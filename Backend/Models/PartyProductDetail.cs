using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PARTY_PRODUCT_DETAIL")]
    public partial class PartyProductDetail
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PARTY_ID")]
        public int? PartyId { get; set; }
        [Column("BAR_CODE")]
        [StringLength(500)]
        public string BarCode { get; set; }
        [Column("ITEM_NAME")]
        [StringLength(200)]
        public string ItemName { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("SALE_PRICE")]
        public decimal? SalePrice { get; set; }
        [Column("DISCOUNT")]
        public decimal? Discount { get; set; }
        [Column("FLAT_DISC_ON_EACH_QTY")]
        public decimal? FlatDiscOnEachQty { get; set; }
        [Column("GST")]
        [StringLength(50)]
        public string Gst { get; set; }
        [Column("DISCPER2")]
        public decimal? Discper2 { get; set; }
        [Column("GSTPER2")]
        public decimal? Gstper2 { get; set; }
        [Column("REMARKS")]
        [StringLength(200)]
        public string Remarks { get; set; }
    }
}
