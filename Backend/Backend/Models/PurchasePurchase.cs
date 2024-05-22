using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchasePurchase
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Expiry { get; set; }
        public int? BonusQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Discbypercent { get; set; }
        public decimal? Discbyvalue { get; set; }
        public decimal? TotalExcTax { get; set; }
        public decimal? Gstbypercent { get; set; }
        public decimal? Gstbyvalue { get; set; }
        public decimal? TotalIncludeTax { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? SaleDisc { get; set; }
        public decimal? Marginbypercent { get; set; }
        public decimal? NetRate { get; set; }
        public string PartyName { get; set; }
        public string Remarks { get; set; }
        public string PartyInv { get; set; }
        public bool? Approved { get; set; }
        public int? RecentPurchasePrice { get; set; }
        public int? TotalStock { get; set; }
        public decimal? AvgPrice { get; set; }
        public int? DiscFlatEn { get; set; }
        public int? MiscEn { get; set; }
        public decimal? RetailPrice { get; set; }
        public int? QtyPack { get; set; }
        public int? LooseQty { get; set; }
        public int? TotalQty { get; set; }
        public int? BonusQty { get; set; }
        public int? DescPercValue { get; set; }
        public int? DiscFlatValue { get; set; }
        public int? DiscFlatValue2 { get; set; }
        public int? GstValue { get; set; }
        public int? GstValue2 { get; set; }
        public int? TotalExecTax { get; set; }
        public int? TotalIncTax { get; set; }
        public int? BonusValue { get; set; }
        public int? GrandTotal { get; set; }
    }
}
