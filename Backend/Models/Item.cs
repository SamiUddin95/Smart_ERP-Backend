using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM")]
    public partial class Item
    {
        public Item()
        {
            ChildItem = new HashSet<ChildItem>();
        }

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
        [Column("CREATED_ON")]
        [StringLength(30)]
        public string CreatedOn { get; set; }
        [Column("UPDATED_ON")]
        [StringLength(30)]
        public string UpdatedOn { get; set; }
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
        [Column("CURRENT_STOCK")]
        public int? CurrentStock { get; set; }
        [Column("LAST_NET_COST")]
        public int? LastNetCost { get; set; }
        [Column("NET_SALE_PRICE")]
        public int? NetSalePrice { get; set; }
        [Column("SNO")]
        public long? Sno { get; set; }
        [Column("PICTURE")]
        public byte[] Picture { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("Item")]
        public ItemBrand Brand { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("Item")]
        public ItemCategory Category { get; set; }
        [ForeignKey("ClassId")]
        [InverseProperty("Item")]
        public ItemClass Class { get; set; }
        [ForeignKey("ManufacturerId")]
        [InverseProperty("Item")]
        public ItemManufacturer Manufacturer { get; set; }
        [InverseProperty("Item")]
        public ICollection<ChildItem> ChildItem { get; set; }
    }
}
