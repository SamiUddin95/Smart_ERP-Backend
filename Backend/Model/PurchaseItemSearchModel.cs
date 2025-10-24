namespace Backend.Model
{
    public class PurchaseItemSearchModel
    {
        public string itemName { get; set; }
        public string barCode { get; set; }
        public decimal salePrice { get; set; }
        public decimal saleDisc { get; set; }
        public decimal purchasePrice { get; set; }
        public int itemId { get; set; }
    }
}
