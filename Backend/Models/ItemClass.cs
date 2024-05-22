using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemClass
    {
        public ItemClass()
        {
            ItemItems = new HashSet<ItemItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? CategoryId { get; set; }

        public ItemCategory Category { get; set; }
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
