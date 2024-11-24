using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AlternateItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string AliasName { get; set; }
        public decimal Qty { get; set; }
        public decimal? Salediscperc { get; set; }
        public decimal? Salediscflat { get; set; }
        public string Remarks { get; set; }
    }
}
