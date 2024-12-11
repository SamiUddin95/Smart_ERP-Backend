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
        [Column("ALTERNATE_ITEM_NAME")]
        [StringLength(250)]
        public string AlternateItemName { get; set; }
        [Column("QTY")]
        public decimal Qty { get; set; }
        [Column("SALEPRICE")]
        public decimal? Saleprice { get; set; }
        [Column("SALEDISC")]
        public decimal? Saledisc { get; set; }
        [Column("REMARKS")]
        [StringLength(250)]
        public string Remarks { get; set; }
        [Column("BARCODE")]
        [StringLength(50)]
        public string Barcode { get; set; }
        [Column("NETSALEPRICE")]
        public decimal? Netsaleprice { get; set; }
    }
}
