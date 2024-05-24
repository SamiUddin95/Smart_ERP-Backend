using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("month")]
    public partial class Month
    {
        [Column("month_id")]
        public int MonthId { get; set; }
        [Column("month_name")]
        [StringLength(50)]
        public string MonthName { get; set; }
    }
}
