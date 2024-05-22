using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;


namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PurchaseOrderController
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllOpeningPurchase")]
        public IEnumerable<PurchaseOpeningPurchase> getAllOpeningPurchase()
        {
            return bMSContext.PurchaseOpeningPurchase.ToList();
        }
        [HttpPost]
        [Route("/api/createOpeningPurchase")]
        public object OpeningPurchase(PurchaseOpeningPurchase openingPurchase)
        {
            try
            {
                var OpenPurchk = bMSContext.PurchaseOpeningPurchase.SingleOrDefault(u => u.Id == openingPurchase.Id);
                if (OpenPurchk != null)
                {

                    OpenPurchk.Id = openingPurchase.Id;
                    OpenPurchk.Date = openingPurchase.Date;
                    OpenPurchk.AccName = openingPurchase.Barcode;
                    OpenPurchk.Godown = openingPurchase.Godown;
                    OpenPurchk.Vehicleno = openingPurchase.Vehicleno;
                    OpenPurchk.Remarks = openingPurchase.Remarks;
                    OpenPurchk.Gstmode = openingPurchase.Gstmode;
                    OpenPurchk.Barcode = openingPurchase.Barcode;
                    OpenPurchk.Itemname = openingPurchase.Itemname;
                    OpenPurchk.Qty = openingPurchase.Qty;
                    OpenPurchk.Bonus = openingPurchase.Bonus;
                    OpenPurchk.Purprice = openingPurchase.Purprice;
                    OpenPurchk.Disc = openingPurchase.Disc;
                    OpenPurchk.Flatdisc = openingPurchase.Flatdisc;
                    OpenPurchk.Totalexctax = openingPurchase.Totalexctax;
                    OpenPurchk.Gst = openingPurchase.Gst;
                    OpenPurchk.Gstval = openingPurchase.Gstval;
                    OpenPurchk.TotalIncTax = openingPurchase.TotalIncTax;
                    OpenPurchk.Saleprice = openingPurchase.Saleprice;
                    OpenPurchk.Margin = openingPurchase.Margin;
                    OpenPurchk.Markup = openingPurchase.Markup;
                    OpenPurchk.Netrate = openingPurchase.Netrate;
                    OpenPurchk.Misc = openingPurchase.Misc;
                    OpenPurchk.DiscFlatEn = openingPurchase.DiscFlatEn;
                    OpenPurchk.Stock = openingPurchase.Stock;
                    OpenPurchk.RecentPurPrice = openingPurchase.RecentPurPrice;
                    OpenPurchk.TotalStock = openingPurchase.TotalStock;
                    OpenPurchk.AvgPrice = openingPurchase.AvgPrice;
                    OpenPurchk.WithholdingTaxPerc = openingPurchase.WithholdingTaxPerc;
                    OpenPurchk.TotalAmount = openingPurchase.TotalAmount;
                    OpenPurchk.QtyPack = openingPurchase.QtyPack;
                    OpenPurchk.LooseQty = openingPurchase.LooseQty;
                    OpenPurchk.TotalQty = openingPurchase.TotalQty;
                    OpenPurchk.BonusQty = openingPurchase.BonusQty;
                    OpenPurchk.DiscPerValue = openingPurchase.DiscPerValue;
                    OpenPurchk.DiscFlatValue = openingPurchase.DiscFlatValue;
                    OpenPurchk.DiscValue2 = openingPurchase.DiscValue2;
                    OpenPurchk.GstValue2 = openingPurchase.GstValue2;
                    OpenPurchk.GrantTotal = openingPurchase.GrantTotal;
                    bMSContext.PurchaseOpeningPurchase.Update(OpenPurchk);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = OpenPurchk.Id });
                }
                else
                {
                    PurchaseOpeningPurchase purchaseOpeningPurchase = new PurchaseOpeningPurchase();

                    purchaseOpeningPurchase.Id = openingPurchase.Id;
                    purchaseOpeningPurchase.Date = openingPurchase.Date;
                    purchaseOpeningPurchase.AccName = openingPurchase.Barcode;
                    purchaseOpeningPurchase.Godown = openingPurchase.Godown;
                    purchaseOpeningPurchase.Vehicleno = openingPurchase.Vehicleno;
                    purchaseOpeningPurchase.Remarks = openingPurchase.Remarks;
                    purchaseOpeningPurchase.Gstmode = openingPurchase.Gstmode;
                    purchaseOpeningPurchase.Barcode = openingPurchase.Barcode;
                    purchaseOpeningPurchase.Itemname = openingPurchase.Itemname;
                    purchaseOpeningPurchase.Qty = openingPurchase.Qty;
                    purchaseOpeningPurchase.Bonus = openingPurchase.Bonus;
                    purchaseOpeningPurchase.Purprice = openingPurchase.Purprice;
                    purchaseOpeningPurchase.Disc = openingPurchase.Disc;
                    purchaseOpeningPurchase.Flatdisc = openingPurchase.Flatdisc;
                    purchaseOpeningPurchase.Totalexctax = openingPurchase.Totalexctax;
                    purchaseOpeningPurchase.Gst = openingPurchase.Gst;
                    purchaseOpeningPurchase.Gstval = openingPurchase.Gstval;
                    purchaseOpeningPurchase.TotalIncTax = openingPurchase.TotalIncTax;
                    purchaseOpeningPurchase.Saleprice = openingPurchase.Saleprice;
                    purchaseOpeningPurchase.Margin = openingPurchase.Margin;
                    purchaseOpeningPurchase.Markup = openingPurchase.Markup;
                    purchaseOpeningPurchase.Netrate = openingPurchase.Netrate;
                    purchaseOpeningPurchase.Misc = openingPurchase.Misc;
                    purchaseOpeningPurchase.DiscFlatEn = openingPurchase.DiscFlatEn;
                    purchaseOpeningPurchase.Stock = openingPurchase.Stock;
                    purchaseOpeningPurchase.RecentPurPrice = openingPurchase.RecentPurPrice;
                    purchaseOpeningPurchase.TotalStock = openingPurchase.TotalStock;
                    purchaseOpeningPurchase.AvgPrice = openingPurchase.AvgPrice;
                    purchaseOpeningPurchase.WithholdingTaxPerc = openingPurchase.WithholdingTaxPerc;
                    purchaseOpeningPurchase.TotalAmount = openingPurchase.TotalAmount;
                    purchaseOpeningPurchase.QtyPack = openingPurchase.QtyPack;
                    purchaseOpeningPurchase.LooseQty = openingPurchase.LooseQty;
                    purchaseOpeningPurchase.TotalQty = openingPurchase.TotalQty;
                    purchaseOpeningPurchase.BonusQty = openingPurchase.BonusQty;
                    purchaseOpeningPurchase.DiscPerValue = openingPurchase.DiscPerValue;
                    purchaseOpeningPurchase.DiscFlatValue = openingPurchase.DiscFlatValue;
                    purchaseOpeningPurchase.DiscValue2 = openingPurchase.DiscValue2;
                    purchaseOpeningPurchase.GstValue2 = openingPurchase.GstValue2;
                    purchaseOpeningPurchase.GrantTotal = openingPurchase.GrantTotal;
                    bMSContext.PurchaseOpeningPurchase.Add(purchaseOpeningPurchase);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = purchaseOpeningPurchase.Id });
                }
            }

            catch (Exception ex)
            {
                JsonConvert.SerializeObject(new { msg = ex.Message });
            }
            return JsonConvert.SerializeObject(new { msg = "Message" });

        }
        [HttpGet]
        [Route("/api/deleteOpeningPurchaseById")]
        public object deleteOpeningPurchaseById(int id)
        {
            try
            {
                var delOpenpurc = bMSContext.PurchaseOpeningPurchase.SingleOrDefault(u => u.Id == id);
                if (delOpenpurc != null)
                {
                    bMSContext.PurchaseOpeningPurchase.Remove(delOpenpurc);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delOpenpurc.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getOpenPurchaseById")]
        public IEnumerable<PurchaseOpeningPurchase> getOpenPurchaseById(int id)
        {
            return bMSContext.PurchaseOpeningPurchase.Where(u => u.Id == id).ToList();
        }
    }
}
