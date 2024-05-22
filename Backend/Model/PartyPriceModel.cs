using System.Collections.Generic;

namespace Backend.Model
{
    public class PartyPriceDto
    {
        public int id { get; set; }
        public int partyId { get; set; }
        public List<PartyPriceData> partyPriceData{ get; set; }
        public class PartyPriceData {
            public string BarCode { get; set; }
            public string ItemName{ get; set; }
            public int BonusQty { get; set; }
            public int SalePrice{ get; set; }
            public int FlatDesconeachQty { get; set; }
            public int GST { get; set; }
            public int GSTPer2 { get; set; }
            public string Remakrs { get; set; }
            public int Discount { get; set; }
            public int Discount2 { get; set; }
        }
    }
}
