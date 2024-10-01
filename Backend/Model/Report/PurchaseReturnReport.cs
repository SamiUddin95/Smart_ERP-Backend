namespace Backend.Model.Report
{
    public class PurchaseReturnReport
    {
        public string SUPPLIER_NAME { get; set; }
        public decimal GRAND_TOTAL { get; set; }
        public decimal TOTAL_INC_TAX { get; set; }
        public decimal TOTAL_EXC_TAX { get; set; }
        public int TOTAL_QTY { get; set; }
        public int PARTY_ID { get; set; } 
    }
}
