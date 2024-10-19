
using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public class PurchaseReturnModel
    {

        public long Id { get; set; }
        public long OrderNo { get; set; }
        public int PartyId { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public string PurSno { get; set; }
        public string ItemType { get; set; }
        public int TotalQty { get; set; }
        public int LooseQty { get; set; }
        public int BonusQty { get; set; }
        public int QtyPack { get; set; }
        public decimal TotalExcTax { get; set; }
        public decimal TotalIncTax { get; set; }
        public decimal AvgPrice { get; set; }
        public int? TotalStock { get; set; } 
        public decimal? Total { get; set; }
        public decimal? Disc { get;  set; }
        public decimal? GrandTotal { get; set; }
        public decimal? flatDisc { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public List<PurchaseReturnDetailModel> purcOrderDtlModel {get;set;}
    }
    public partial class PurchaseReturnDetailModel
    {
        public long Id { get; set; }
        public long? OrderReturnId { get; set; }
        public string Barcode { get; set; }
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public int? Qty { get; set; }
        public decimal? FullRate { get; set; }
        public decimal? Disc { get; set; }
        public decimal? FlatDisc { get; set; }
        public decimal? Total { get; set; }
    }
}
