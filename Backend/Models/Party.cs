using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PARTY")]
    public partial class Party
    {
        public Party()
        {
            Item = new HashSet<Item>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("PARTY_NAME")]
        [StringLength(100)]
        public string PartyName { get; set; }
        [Column("MOBILE_NO")]
        [StringLength(50)]
        public string MobileNo { get; set; }
        [Column("ADDRESS")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column("TEL_PHONE_NO")]
        [StringLength(50)]
        public string TelPhoneNo { get; set; }
        [Column("FAX_NO")]
        [StringLength(50)]
        public string FaxNo { get; set; }
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("TAX_REG_NO")]
        [StringLength(50)]
        public string TaxRegNo { get; set; }
        [Column("NTN")]
        [StringLength(50)]
        public string Ntn { get; set; }
        [Column("NIC")]
        [StringLength(50)]
        public string Nic { get; set; }
        [Column("AREA_ID")]
        public int? AreaId { get; set; }
        [Column("CITY_ID")]
        public int? CityId { get; set; }
        [Column("SUB_AREA_ID")]
        public int? SubAreaId { get; set; }
        [Column("ADDRESS_1")]
        [StringLength(500)]
        public string Address1 { get; set; }
        [Column("CONTACT_PERSON")]
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Column("CATEGORY_ID")]
        public int? CategoryId { get; set; }
        [Column("DUE_DAYS")]
        public int? DueDays { get; set; }
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
        [Column("SNO")]
        public long? Sno { get; set; }

        [InverseProperty("Party")]
        public ICollection<Item> Item { get; set; }
    }
}
