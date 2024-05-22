using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Account
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int AccountCategoryId { get; set; }
        public int AccountTypeId { get; set; }
        public string ManualCode { get; set; }
        public string KindCode { get; set; }
        public string Priority { get; set; }
        public int? TypeId { get; set; }
        public int? SubCdTypeId { get; set; }
        public string DiscNo { get; set; }
        public decimal? BalanceLimit { get; set; }
        public decimal? TaxLimit { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
