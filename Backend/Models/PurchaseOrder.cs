using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_ORDER")]
    public partial class PurchaseOrder
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("PARTY_ID")]
        public int? PartyId { get; set; }
        [Column("DATE_OF_INVOICE")]
        [StringLength(50)]
        public string DateOfInvoice { get; set; }
        [Column("REMARKS")]
        [StringLength(50)]
        public string Remarks { get; set; }
        [Column("CREATED_AT")]
        [StringLength(50)]
        public string CreatedAt { get; set; }
        [Column("INV_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? InvTotal { get; set; }
        [Column("START_DATE")]
        [StringLength(50)]
        public string StartDate { get; set; }
        [Column("END_DATE")]
        [StringLength(50)]
        public string EndDate { get; set; }
        [Column("DISC")]
        public decimal? Disc { get; set; }
        [Column("POSTED")]
        [StringLength(50)]
        public string Posted { get; set; }
        [Column("ZERO_QTY")]
        public int? ZeroQty { get; set; }
        [Column("PROJECTION_DAYS")]
        [StringLength(50)]
        public string ProjectionDays { get; set; }
        [Column("PUR_ORDER_TERM")]
        public string PurOrderTerm { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("PurchaseOrder")]
        public Location Location { get; set; }
    }
}
