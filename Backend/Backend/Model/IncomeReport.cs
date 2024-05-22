using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class IncomeReport
    {
        public decimal totalElctricityBill { get; set; }
        public decimal totalMaintenance { get; set; }
        public decimal totalRent { get; set; }
        public decimal totalAmount { get; set; }
    }
}
