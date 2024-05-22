using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseOpeningPurchase
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string AccName { get; set; }
        public byte[] Godown { get; set; }
        public string Vehicleno { get; set; }
        public string Remarks { get; set; }
        public string Gstmode { get; set; }
        public string Barcode { get; set; }
        public string Itemname { get; set; }
        public int? Qty { get; set; }
        public string Bonus { get; set; }
        public decimal? Purprice { get; set; }
        public string Disc { get; set; }
        public string Flatdisc { get; set; }
        public string Totalexctax { get; set; }
        public string Gst { get; set; }
        public string Gstval { get; set; }
        public string TotalIncTax { get; set; }
        public decimal? Saleprice { get; set; }
        public string Margin { get; set; }
        public string Markup { get; set; }
        public string Netrate { get; set; }
        public string Misc { get; set; }
        public string DiscFlatEn { get; set; }
        public string Stock { get; set; }
        public decimal? RecentPurPrice { get; set; }
        public string TotalStock { get; set; }
        public decimal? AvgPrice { get; set; }
        public string WithholdingTaxPerc { get; set; }
        public decimal? TotalAmount { get; set; }
        public string QtyPack { get; set; }
        public string LooseQty { get; set; }
        public string TotalQty { get; set; }
        public string BonusQty { get; set; }
        public string DiscPerValue { get; set; }
        public string DiscFlatValue { get; set; }
        public string DiscValue2 { get; set; }
        public string GstValue2 { get; set; }
        public decimal? GrantTotal { get; set; }
    }
}
