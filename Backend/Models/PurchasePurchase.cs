using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_PURCHASE")]
    public partial class PurchasePurchase
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("BARCODE")]
        public string Barcode { get; set; }
        [Column("ITEM_NAME")]
        [StringLength(50)]
        public string ItemName { get; set; }
        [Column("QUANTITY")]
        public int? Quantity { get; set; }
        [Column("EXPIRY", TypeName = "date")]
        public DateTime? Expiry { get; set; }
        [Column("BONUS_QUANTITY")]
        public int? BonusQuantity { get; set; }
        [Column("PURCHASE_PRICE", TypeName = "decimal(18, 4)")]
        public decimal? PurchasePrice { get; set; }
        [Column("DISCBYPERCENT", TypeName = "decimal(18, 4)")]
        public decimal? Discbypercent { get; set; }
        [Column("DISCBYVALUE", TypeName = "decimal(18, 4)")]
        public decimal? Discbyvalue { get; set; }
        [Column("TOTAL_EXC_TAX", TypeName = "decimal(18, 4)")]
        public decimal? TotalExcTax { get; set; }
        [Column("GSTBYPERCENT")]
        public decimal? Gstbypercent { get; set; }
        [Column("GSTBYVALUE")]
        public decimal? Gstbyvalue { get; set; }
        [Column("TOTAL_INCLUDE_TAX", TypeName = "decimal(18, 4)")]
        public decimal? TotalIncludeTax { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(18, 4)")]
        public decimal? SalePrice { get; set; }
        [Column("SALE_DISC", TypeName = "decimal(18, 4)")]
        public decimal? SaleDisc { get; set; }
        [Column("MARGINBYPERCENT")]
        public decimal? Marginbypercent { get; set; }
        [Column("NET_RATE", TypeName = "decimal(18, 5)")]
        public decimal? NetRate { get; set; }
        [Column("PARTY_NAME")]
        [StringLength(50)]
        public string PartyName { get; set; }
        [Column("REMARKS")]
        [StringLength(250)]
        public string Remarks { get; set; }
        [Column("PARTY_INV")]
        [StringLength(50)]
        public string PartyInv { get; set; }
        [Column("APPROVED")]
        public bool? Approved { get; set; }
        [Column("RECENT_PURCHASE_PRICE")]
        public int? RecentPurchasePrice { get; set; }
        [Column("TOTAL_STOCK")]
        public int? TotalStock { get; set; }
        [Column("AVG_PRICE")]
        public decimal? AvgPrice { get; set; }
        [Column("DISC_FLAT_EN")]
        public int? DiscFlatEn { get; set; }
        [Column("MISC_EN")]
        public int? MiscEn { get; set; }
        [Column("RETAIL_PRICE")]
        public decimal? RetailPrice { get; set; }
        [Column("QTY_PACK")]
        public int? QtyPack { get; set; }
        [Column("LOOSE_QTY")]
        public int? LooseQty { get; set; }
        [Column("TOTAL_QTY")]
        public int? TotalQty { get; set; }
        [Column("BONUS_QTY")]
        public int? BonusQty { get; set; }
        [Column("DESC_PERC_VALUE")]
        public int? DescPercValue { get; set; }
        [Column("DISC_FLAT_VALUE")]
        public int? DiscFlatValue { get; set; }
        [Column("DISC_FLAT_VALUE2")]
        public int? DiscFlatValue2 { get; set; }
        [Column("GST_VALUE")]
        public int? GstValue { get; set; }
        [Column("GST_VALUE2")]
        public int? GstValue2 { get; set; }
        [Column("TOTAL_EXEC_TAX")]
        public int? TotalExecTax { get; set; }
        [Column("TOTAL_INC_TAX")]
        public int? TotalIncTax { get; set; }
        [Column("BONUS_VALUE")]
        public int? BonusValue { get; set; }
        [Column("GRAND_TOTAL")]
        public int? GrandTotal { get; set; }
    }
}
