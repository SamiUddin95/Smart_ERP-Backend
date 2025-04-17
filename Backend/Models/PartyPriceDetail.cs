using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PARTY_PRICE_DETAIL")]
    public partial class PartyPriceDetail
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PARTY_ID")]
        public int PartyId { get; set; }
        [Required]
        [StringLength(255)]
        public string BarCode { get; set; }
        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }
        public int BonusQty { get; set; }
        public int SalePrice { get; set; }
        public int FlatDesconeachQty { get; set; }
        [Column("GST")]
        public int Gst { get; set; }
        [Column("GSTPer2")]
        public int Gstper2 { get; set; }
        [StringLength(300)]
        public string Remarks { get; set; }
        [Column("DISCOUNT")]
        public int Discount { get; set; }
        [Column("DISCOUNT2")]
        public int Discount2 { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
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
