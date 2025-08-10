using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ItemManufacturer
    {
        public ItemManufacturer()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephoneno { get; set; }
        public string Telephoneno2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] Picture { get; set; }
        public long? Sno { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
