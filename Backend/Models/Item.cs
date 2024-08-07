﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string AliasName { get; set; }
        public string ItemName { get; set; }
        public int PurchasePrice { get; set; }
        public int? SalePrice { get; set; }
        public int CategoryId { get; set; }
        public int ClassId { get; set; }
        public int ManufacturerId { get; set; }
        public string Remarks { get; set; }
        public int? RecentPurchase { get; set; }
        public int BrandId { get; set; }
        public int? Discflat { get; set; }
        public int Lockdisc { get; set; }

        public ItemBrand Brand { get; set; }
        public ItemCategory Category { get; set; }
        public ItemClass Class { get; set; }
        public ItemManufacturer Manufacturer { get; set; }
    }
}
