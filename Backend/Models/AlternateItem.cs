using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AlternateItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string AlternateItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Saledisc { get; set; }
        public string Remarks { get; set; }
        public string Barcode { get; set; }
        public decimal? Netsaleprice { get; set; }
    }
}
