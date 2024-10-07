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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
