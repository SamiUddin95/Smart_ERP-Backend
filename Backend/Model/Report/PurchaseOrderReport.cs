namespace Backend.Model.Report
{
    public class PurchaseOrderReport
    {
        public string SUPPLIERNAME { get; set; }
        public int PARTYID { get; set; }
        public int ITEMQTY { get; set; }
        public string CREATEDON { get; set; }
        public decimal TOTALAMOUNT { get; set; }
        public decimal TOTALDISCOUNT { get; set; }
    }
}
