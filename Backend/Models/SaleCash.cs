using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SaleCash
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string TillOpenNo { get; set; }
        public string TillCloseNo { get; set; }
        public string CashInDateTime { get; set; }
        public string CashOutDateTime { get; set; }
        public decimal? CashInAmount { get; set; }
        public decimal? CashOutAmount { get; set; }
        public string Notes { get; set; }
        public int? LocationId { get; set; }
    }
}
