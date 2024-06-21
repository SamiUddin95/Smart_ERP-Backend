using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Rent
    {
        public int RentId { get; set; }
        public int ShopId { get; set; }
        public int MonthId { get; set; }
        public decimal Rent1 { get; set; }
        public string Date { get; set; }
        public string Year { get; set; }
        public int AgreementTypeId { get; set; }
        public decimal? ElectricityBill { get; set; }
        public decimal? Maintenance { get; set; }
    }
}
