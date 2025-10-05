using System.Collections.Generic;

namespace Backend.Model
{
    public class PostUnPostReturnModel
    {
        public string postedBy { get; set; }
        public int purchaseId { get; set; }
        public List<PostUnPostReturnDtlModel> PostUnPostRtnDtlModel { get; set; }

    }
    public class PostUnPostReturnDtlModel
    {
        public string barCode { get; set; }
        public double? qty { get; set; }
        public double? fullRate { get; set; }
        public double? flatDisc { get; set; }
        public double? total { get; set; }
        public double? disc { get; set; }
        public double? SalePrice { get; set; }
        public double? SaleDisc { get; set; }
        public double? NetSalePrice { get; set; }
    }
}
