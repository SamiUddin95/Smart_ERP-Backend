using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemClass
    {
        public ItemClass()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public long? Sno { get; set; }

        public ItemCategory Category { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
