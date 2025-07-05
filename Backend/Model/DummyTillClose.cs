namespace Backend.Model
{
    public class DummyTillClose
    {
        public decimal GrossSale { get; set; }
        public decimal TotalDisc { get; set; }
        public decimal TotalGst { get; set; }
        public decimal Misc { get; set; }
        public decimal TotalCreditAmount { get; set; }
        public decimal TotalSaleReturn { get; set; }
        public decimal TillOpenAmount { get; set; }
        public decimal CashIn { get; set; }
        public decimal CashOut { get; set; }
        public decimal NetCash { get; set; }
        public decimal Shortage { get; set; }
        public decimal Netsale { get; set; }
    }
}
