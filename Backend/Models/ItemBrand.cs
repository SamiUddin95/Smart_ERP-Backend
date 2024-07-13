using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemBrand
    {
        public ItemBrand()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
