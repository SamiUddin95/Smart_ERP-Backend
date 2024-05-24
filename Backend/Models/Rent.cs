using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("rent")]
    public partial class Rent
    {
        [Column("rent_id")]
        public int RentId { get; set; }
        [Column("shop_id")]
        public int ShopId { get; set; }
        [Column("month_id")]
        public int MonthId { get; set; }
        [Column("rent")]
        public decimal Rent1 { get; set; }
        [Required]
        [Column("date")]
        [StringLength(50)]
        public string Date { get; set; }
        [Required]
        [Column("year")]
        [StringLength(5)]
        public string Year { get; set; }
        [Column("agreement_type_id")]
        public int AgreementTypeId { get; set; }
        [Column("electricity_bill")]
        public decimal? ElectricityBill { get; set; }
        [Column("maintenance")]
        public decimal? Maintenance { get; set; }
    }
}
