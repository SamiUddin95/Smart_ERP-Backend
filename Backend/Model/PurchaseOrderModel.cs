
using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public class PurchaseOrderModel
    {
        public long Id { get; set; }
        public int PartyId { get; set; } 
        public string ProjectionDays { get; set; }
        public decimal InvTotal { get; set; }
        public decimal Disc  { get; set; }
        public string DateOfInvoice { get; set; }
        public string PurOrderTerm { get; set; }
        public string PoCategory { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedAt { get; set; } 
        public List<PurchaseOrderDetailModel> purcOrderDtlModel {get;set;}


    }
    public class PurchaseOrderDetailModel
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string BarCode { get; set; }
        public int? ItemId { get; set; } 
        public int? SoldQty { get; set; }
        public int? RtnQty { get; set; }
        public int? NetSaleQty { get; set; }
        public int? CurrentStock { get; set; }
        public int? RequiredQty { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? Rate { get; set; }
        public int? Qty { get; set; }
        public decimal? RecPrice { get; set; }
        public int? Total { get; set; }
    }
}
