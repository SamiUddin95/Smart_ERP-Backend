using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseOrderDetail
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string BarCode { get; set; }
        public int? ItemId { get; set; }
        public int? SoldQty { get; set; }
        public int? RtnQty { get; set; }
        public int? NetSaleQty { get; set; }
        public decimal? Rate { get; set; }
        public int? CurrentStock { get; set; }
        public decimal? RequiredQty { get; set; }
        public decimal? Total { get; set; }
    }
}
