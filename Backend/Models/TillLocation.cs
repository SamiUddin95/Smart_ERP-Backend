using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("TILL_LOCATION")]
    public partial class TillLocation
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
        [Column("TILL_NUMBER")]
        public long? TillNumber { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("TillLocation")]
        public Location Location { get; set; }
    }
}
