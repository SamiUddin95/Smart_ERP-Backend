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

        public ItemCategory Category { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
