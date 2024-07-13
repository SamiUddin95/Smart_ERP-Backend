
using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public class PurchaseOrderModel
    {
        public long Id { get; set; }
        public int PartyId { get; set; } 
        public string DateOfInvoice { get; set; }
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
        public int? NetSale { get; set; }
        public int? CurrentStock { get; set; }
        public string? RequiredPack { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? FullRate { get; set; }
        public int? Qty { get; set; }
        public decimal? RecPrice { get; set; }
        public int? Total { get; set; }
    }
}
