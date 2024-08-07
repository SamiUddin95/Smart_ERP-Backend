﻿using System;
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
        public int? Priority { get; set; }
        public int DepartmentId { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Description { get; set; }

        public ICollection<Item> Item { get; set; }
        public ICollection<ItemClass> ItemClass { get; set; }
    }
}
