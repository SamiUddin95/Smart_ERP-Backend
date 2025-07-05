using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("MINIMUM_QTY")]
    public partial class MinimumQty
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("SNO")]
        public long? Sno { get; set; }
        [Column("BARCODE")]
        [StringLength(250)]
        public string Barcode { get; set; }
        [Column("ITEM_NAME")]
        [StringLength(250)]
        public string ItemName { get; set; }
        [Column("CURRENT_STOCK")]
        public int? CurrentStock { get; set; }
        [Column("NET_RATE")]
        public decimal? NetRate { get; set; }
        [Column("MINIMUM_QTY")]
        public int? MinimumQty1 { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
    }
}
