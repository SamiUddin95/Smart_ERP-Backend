using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseReturn
    {
        public long Id { get; set; }
        public long OrderNo { get; set; }
        public int PartyId { get; set; }
        public string Date { get; set; }
        public string ItemType { get; set; }
        public int? UserId { get; set; }
        public string PurSno { get; set; }
        public int? TotalQty { get; set; }
        public int? LooseQty { get; set; }
        public int? BonusQty { get; set; }
        public int? QtyPack { get; set; }
        public decimal? TotalExcTax { get; set; }
        public decimal? TotalIncTax { get; set; }
        public decimal? AvgPrice { get; set; }
        public decimal? TotalStock { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Total { get; set; } 
        public decimal? Disc { get; set; }
        public decimal? FlatDisc { get; set; }
    }
}
