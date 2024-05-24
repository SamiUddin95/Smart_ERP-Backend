using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Backend.Model
{
    public class CounterSaleModel
    {
        public long Id { get; set; }
        public decimal? GrossSale { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FlatDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? Misc { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Return { get; set; }
        public decimal? EarnedPoints { get; set; }
        public decimal? NetAmount { get; set; }

        public List<CounterSaleDetailModel> counterSaleDetails { get; set; }
    }
    public class CounterSaleDetailModel 
    {
        public long Id { get; set; }
        public long CounterSaleId { get; set; }
        public string BarCode { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? NetTotal { get; set; }
    }
}
