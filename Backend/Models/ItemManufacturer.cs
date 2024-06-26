using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemManufacturer
    {
        public ItemManufacturer()
        {
            ItemItems = new HashSet<ItemItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephoneno { get; set; }
        public string Telephoneno2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
