using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Backend.Model
{
    public class CounterSaleModel
    {
        public long Id { get; set; }
        public decimal? GrossSale { get; set; }
        public decimal? CashCharged { get; set; }
        public decimal? CashBack { get; set; }
        public decimal? CashReceived { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExtraChargesPer { get; set; }
        public decimal? ExtraCharges { get; set; }
        public decimal? DiscountPerc { get; set; }
        public decimal? FlatDisc { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? Misc { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Return { get; set; }
        public decimal? EarnedPoints { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? NetSaleTotal { get; set; }
        public decimal? FinalAmount { get; set; }
        public decimal? remainingCreditAmount { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public string InvoiceType { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string MachineName { get; set; }
        public string AmountWords { get; set; }
        public decimal? InvoiceBalance { get; set; }
        public List<CounterSaleDetailModel> counterSaleDetails { get; set; }
    }
    public class CounterSaleDetailModel 
    {
        public long Id { get; set; }
        public long CounterSaleId { get; set; }
        public string BarCode { get; set; }
        public string? ItemName { get; set; }
        public int? Qty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? NetSalePrice { get; set; }
    }
}
