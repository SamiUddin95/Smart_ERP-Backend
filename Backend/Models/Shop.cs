using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Shop
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopSize { get; set; }
        public string ShopLocation { get; set; }
        public int ShopTypeId { get; set; }
        public string AgreementStartDate { get; set; }
    }
}
