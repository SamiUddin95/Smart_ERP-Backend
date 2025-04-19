using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("LOCATION")]
    public partial class Location
    {
        public Location()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
            TillLocation = new HashSet<TillLocation>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("SERIALNUMBER")]
        public long? Serialnumber { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("ADDRESS")]
        [StringLength(250)]
        public string Address { get; set; }
        [Column("PHONENUMBER")]
        [StringLength(50)]
        public string Phonenumber { get; set; }
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }
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
        [Column("ROYALITY_PERCENT", TypeName = "decimal(10, 2)")]
        public decimal? RoyalityPercent { get; set; }

        [InverseProperty("Location")]
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        [InverseProperty("Location")]
        public ICollection<TillLocation> TillLocation { get; set; }
    }
}
