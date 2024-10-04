using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PARTY_OTHER_CONTACT_DETAIL")]
    public partial class PartyOtherContactDetail
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PARTY_ID")]
        public int? PartyId { get; set; }
        [Column("CELL_NO")]
        [StringLength(50)]
        public string CellNo { get; set; }
        [Column("CONTACT_PERSON")]
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("OFFICE_ADDRESS")]
        [StringLength(200)]
        public string OfficeAddress { get; set; }
        [Column("RES_ADDRESS")]
        [StringLength(200)]
        public string ResAddress { get; set; }
        [Column("REMARKS")]
        [StringLength(200)]
        public string Remarks { get; set; }
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
