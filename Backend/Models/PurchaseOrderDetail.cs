using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseOrderDetail
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string BarCode { get; set; }
        public int? ItemId { get; set; }
        public int? SoldQty { get; set; }
        public int? RtnQty { get; set; }
        public decimal? NetSale { get; set; }
        public int? CurrentStock { get; set; }
        public string RequiredPack { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? FullRate { get; set; }
        public int? Qty { get; set; }
        public decimal? RecPrice { get; set; }
        public int? Total { get; set; }
    }
}
