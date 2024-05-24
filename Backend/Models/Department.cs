using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("DEPARTMENT")]
    public partial class Department
    {
        public Department()
        {
            ItemCategory = new HashSet<ItemCategory>();
            ItemClass = new HashSet<ItemClass>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("DEPARTMENT_NAME")]
        [StringLength(250)]
        public string DepartmentName { get; set; }

        [InverseProperty("Department")]
        public ICollection<ItemCategory> ItemCategory { get; set; }
        [InverseProperty("Department")]
        public ICollection<ItemClass> ItemClass { get; set; }
    }
}
