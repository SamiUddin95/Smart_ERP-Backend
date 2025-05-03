using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Item = new HashSet<Item>();
            ItemClass = new HashSet<ItemClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public string Priority { get; set; }
        public int? DepartmentId { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] Picture { get; set; }
        public long? Sno { get; set; }

        public ICollection<Item> Item { get; set; }
        public ICollection<ItemClass> ItemClass { get; set; }
    }
}
