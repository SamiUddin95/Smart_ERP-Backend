using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Backend.Model
{
    public class SaleReturnModel
    {
        public long Id { get; set; }
        public decimal? GrossSale { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscByValue { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? NetSaleReturnTotal { get; set; }
        public decimal? DiscByPercent { get; set; }
        public decimal? Return { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? GrossSaleReturn { get; set; }
        public string Createdby { get; set; }
        public int UserId { get; set; }
        public string Updatedby { get; set; }
        public List<SaleReturnDetailModel> saleReturnDetails { get; set; }
    }
    public class SaleReturnDetailModel 
    {
        public long Id { get; set; }
        public long SaleReturnId { get; set; }
        public string BarCode { get; set; }
        public string? ItemName { get; set; }
        public int? Qty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? Discount { get; set; } 
    }
}
