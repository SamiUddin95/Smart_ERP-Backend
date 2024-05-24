using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM_ITEMS")]
    public partial class ItemItems
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ALIAS_NAME")]
        [StringLength(50)]
        public string AliasName { get; set; }
        [Required]
        [Column("ITEM_NAME")]
        [StringLength(50)]
        public string ItemName { get; set; }
        [Column("PURCHASE_PRICE")]
        public int PurchasePrice { get; set; }
        [Column("SALE_PRICE")]
        public int? SalePrice { get; set; }
        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }
        [Column("CLASS_ID")]
        public int ClassId { get; set; }
        [Column("MANUFACTURER_ID")]
        public int ManufacturerId { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }
        [Column("RECENT_PURCHASE")]
        public int? RecentPurchase { get; set; }
        [Column("BRAND_ID")]
        public int BrandId { get; set; }
        [Column("DISCFLAT")]
        public int? Discflat { get; set; }
        [Column("LOCKDISC")]
        public int Lockdisc { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("ItemItems")]
        public ItemBrand Brand { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("ItemItems")]
        public ItemCategory Category { get; set; }
        [ForeignKey("ClassId")]
        [InverseProperty("ItemItems")]
        public ItemClass Class { get; set; }
        [ForeignKey("Lockdisc")]
        [InverseProperty("ItemItems")]
        public Active LockdiscNavigation { get; set; }
        [ForeignKey("ManufacturerId")]
        [InverseProperty("ItemItems")]
        public ItemManufacturer Manufacturer { get; set; }
    }
}
