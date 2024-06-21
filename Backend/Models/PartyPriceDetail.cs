using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PartyPriceDetail
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int BonusQty { get; set; }
        public int SalePrice { get; set; }
        public int FlatDesconeachQty { get; set; }
        public int Gst { get; set; }
        public int Gstper2 { get; set; }
        public string Remarks { get; set; }
        public int Discount { get; set; }
        public int Discount2 { get; set; }
    }
}
