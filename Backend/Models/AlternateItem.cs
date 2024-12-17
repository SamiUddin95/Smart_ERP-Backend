using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ALTERNATE_ITEM")]
    public partial class AlternateItem
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ITEM_ID")]
        public int ItemId { get; set; }
        public string AliasName { get; set; }
        public decimal Qty { get; set; }
        public decimal? Salediscperc { get; set; }
        public decimal? Salediscflat { get; set; }
        public string Remarks { get; set; }
    }
}
