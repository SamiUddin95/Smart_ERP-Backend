using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PurchaseController
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllPurchases")]
        public IEnumerable<PurchasePurchase> getAllPurchase()
        {
            return bMSContext.PurchasePurchase.ToList();
        }

        [HttpPost]
        [Route("/api/createPurchase")]
        public object createPurchase(PurchasePurchase purchase)
        {
                try
                {
                    var Purchk = bMSContext.PurchasePurchase.SingleOrDefault(u => u.Id == purchase.Id);
                    if (Purchk != null)
                    {

                        Purchk.Id = purchase.Id;
                        Purchk.Barcode = purchase.Barcode;
                        Purchk.ItemName = purchase.Barcode;
                        Purchk.Quantity = purchase.Quantity;
                        Purchk.Expiry = purchase.Expiry;
                        Purchk.BonusQty = purchase.BonusQty;
                        Purchk.PurchasePrice = purchase.PurchasePrice;
                        Purchk.Discbypercent = purchase.Discbypercent;
                        Purchk.Discbyvalue = purchase.Discbyvalue;
                        Purchk.TotalExcTax = purchase.TotalExcTax;
                        Purchk.Gstbypercent = purchase.Gstbypercent;
                        Purchk.Gstbyvalue = purchase.Gstbyvalue;
                        Purchk.TotalIncludeTax = purchase.TotalIncludeTax;
                        Purchk.SalePrice = purchase.SalePrice;
                        Purchk.SaleDisc = purchase.SaleDisc;
                        Purchk.Marginbypercent = purchase.Marginbypercent;
                        Purchk.NetRate = purchase.NetRate;
                        Purchk.PartyName = purchase.PartyName;
                        Purchk.Remarks = purchase.Remarks;
                        Purchk.PartyInv = purchase.PartyInv;
                        Purchk.Approved = purchase.Approved;
                        Purchk.RecentPurchasePrice = purchase.RecentPurchasePrice;
                        Purchk.TotalStock = purchase.TotalStock;
                        Purchk.AvgPrice = purchase.AvgPrice;
                        Purchk.DiscFlatEn = purchase.DiscFlatEn;
                        Purchk.MiscEn = purchase.MiscEn;
                        Purchk.RetailPrice = purchase.RetailPrice;
                        Purchk.QtyPack = purchase.QtyPack;
                        Purchk.LooseQty = purchase.LooseQty;
                        Purchk.TotalQty = purchase.TotalQty;
                        Purchk.BonusQty = purchase.BonusQty;
                        Purchk.DescPercValue = purchase.DescPercValue;
                        Purchk.DiscFlatValue = purchase.DiscFlatValue;
                        Purchk.DiscFlatValue2 = purchase.DiscFlatValue2;
                        Purchk.GstValue = purchase.GstValue;
                        Purchk.GstValue2 = purchase.GstValue2;
                        Purchk.TotalExecTax = purchase.TotalExecTax;
                        Purchk.TotalIncTax = purchase.TotalIncTax;
                        Purchk.BonusValue = purchase.BonusValue;
                        Purchk.GrandTotal = purchase.GrandTotal;
                        bMSContext.PurchasePurchase.Update(Purchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = Purchk.Id });
                    }
                    else
                    {
                        PurchasePurchase purchase1 = new PurchasePurchase();

                        purchase1.Barcode = purchase.Barcode;
                        purchase1.ItemName = purchase.Barcode;
                        purchase1.Quantity = purchase.Quantity;
                        purchase1.Expiry = purchase.Expiry;
                        purchase1.BonusQty = purchase.BonusQty;
                        purchase1.PurchasePrice = purchase.PurchasePrice;
                        purchase1.Discbypercent = purchase.Discbypercent;
                        purchase1.Discbyvalue = purchase.Discbyvalue;
                        purchase1.TotalExcTax = purchase.TotalExcTax;
                        purchase1.Gstbypercent = purchase.Gstbypercent;
                        purchase1.Gstbyvalue = purchase.Gstbyvalue;
                        purchase1.TotalIncludeTax = purchase.TotalIncludeTax;
                        purchase1.SalePrice = purchase.SalePrice;
                        purchase1.SaleDisc = purchase.SaleDisc;
                        purchase1.Marginbypercent = purchase.Marginbypercent;
                        purchase1.NetRate = purchase.NetRate;
                        purchase1.PartyName = purchase.PartyName;
                        purchase1.Remarks = purchase.Remarks;
                        purchase1.PartyInv = purchase.PartyInv;
                        purchase1.Approved = purchase.Approved;
                        purchase1.RecentPurchasePrice = purchase.RecentPurchasePrice;
                        purchase1.TotalStock = purchase.TotalStock;
                        purchase1.AvgPrice = purchase.AvgPrice;
                        purchase1.DiscFlatEn = purchase.DiscFlatEn;
                        purchase1.MiscEn = purchase.MiscEn;
                        purchase1.RetailPrice = purchase.RetailPrice;
                        purchase1.QtyPack = purchase.QtyPack;
                        purchase1.LooseQty = purchase.LooseQty;
                        purchase1.TotalQty = purchase.TotalQty;
                        purchase1.BonusQty = purchase.BonusQty;
                        purchase1.DescPercValue = purchase.DescPercValue;
                        purchase1.DiscFlatValue = purchase.DiscFlatValue;
                        purchase1.DiscFlatValue2 = purchase.DiscFlatValue2;
                        purchase1.GstValue = purchase.GstValue;
                        purchase1.GstValue2 = purchase.GstValue2;
                        purchase1.TotalExecTax = purchase.TotalExecTax;
                        purchase1.TotalIncTax = purchase.TotalIncTax;
                        purchase1.BonusValue = purchase.BonusValue;
                        purchase1.GrandTotal = purchase.GrandTotal;
                        bMSContext.PurchasePurchase.Add(purchase1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = purchase1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            
        }

        [HttpGet]
        [Route("/api/deletePurchaseById")]
        public object deletePurchaseById(int id)
        {
            try
            {
                var delpurc = bMSContext.PurchasePurchase.SingleOrDefault(u => u.Id == id);
                if (delpurc != null)
                {
                    bMSContext.PurchasePurchase.Remove(delpurc);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delpurc.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getPurchaseById")]
        public IEnumerable<PurchasePurchase> getPurchaseById(int id)
        {
            return bMSContext.PurchasePurchase.Where(u => u.Id == id).ToList();
        }
    }
}
