using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ShopType
    {
        public int ShopTypeId { get; set; }
        public string ShopType1 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
