using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemBrand
    {
        public ItemBrand()
        {
            ItemItems = new HashSet<ItemItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
