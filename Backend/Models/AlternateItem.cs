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
        [Required]
        [Column("ALIAS_NAME")]
        [StringLength(250)]
        public string AliasName { get; set; }
        [Column("QTY")]
        public decimal Qty { get; set; }
        [Column("SALEDISCPERC")]
        public decimal? Salediscperc { get; set; }
        [Column("SALEDISCFLAT")]
        public decimal? Salediscflat { get; set; }
        [Column("REMARKS")]
        [StringLength(250)]
        public string Remarks { get; set; }
    }
}
