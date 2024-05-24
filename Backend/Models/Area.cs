using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("AREA")]
    public partial class Area
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
