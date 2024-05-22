using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class RentedShops
    {
        public int shop_id { get; set; }
        public string shop_name { get; set; }
        public int month_id { get; set; }
        public string month_name { get; set; }
        public decimal electricity_bill { get; set; }
        public decimal maintenance { get; set; }
        public decimal rent { get; set; }
    }
}
