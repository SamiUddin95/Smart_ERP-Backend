﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int? VendorId { get; set; }
        public string Remarks { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? RecentPurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? ItemsQuantity { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? BillTotal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
