using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PARENT_ITEM")]
    public partial class ParentItem
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Required]
        [Column("BARCODE")]
        [StringLength(255)]
        public string Barcode { get; set; }
        [Required]
        [Column("PARENT_NAME")]
        [StringLength(255)]
        public string ParentName { get; set; }
        [Column("UOM")]
        [StringLength(16)]
        public string Uom { get; set; }
        [Column("WEIGHT")]
        public int? Weight { get; set; }
        [Column("NET_COST", TypeName = "decimal(10, 2)")]
        public decimal? NetCost { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? SalePrice { get; set; }
        [Column("DISC_PERC", TypeName = "decimal(10, 2)")]
        public decimal? DiscPerc { get; set; }
        [Column("DISC_VALUE", TypeName = "decimal(10, 2)")]
        public decimal? DiscValue { get; set; }
        [Column("MISC", TypeName = "decimal(10, 2)")]
        public decimal? Misc { get; set; }
        [Column("NET_SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? NetSalePrice { get; set; }
        [Column("PROFIT", TypeName = "decimal(10, 2)")]
        public decimal? Profit { get; set; }
        [Column("MANUAL_SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? ManualSalePrice { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("ParentItem")]
        public Item Item { get; set; }
    }
}
