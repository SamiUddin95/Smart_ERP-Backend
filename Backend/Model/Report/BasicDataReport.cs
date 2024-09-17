using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class BasicDataReport
    {
        public string ITEMNAME { get; set; }
        public string BRANDNAME { get; set; }
        public string MANUFACTURERNAME { get; set; }
        public string CREATEDON { get; set; }
        public decimal SALEPRICE { get; set; }
        public decimal PURCHASEPRICE { get; set; }
    }
}
