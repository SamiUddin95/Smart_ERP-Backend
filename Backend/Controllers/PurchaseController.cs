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
using Backend.Model;
using Newtonsoft.Json.Bson;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PurchaseController
    {
        ERPContext bMSContext = new ERPContext();

        [HttpGet]
        [Route("/api/getAllPurchaseOrder")]
        public IEnumerable<dynamic> getAllPurchase()
        {
            var result = (from po in bMSContext.PurchaseOrder
                          join p in bMSContext.Party on po.PartyId equals p.Id
                          select new
                          {
                              partyId = p.PartyName,
                              dateOfInvoice = po.DateOfInvoice,
                              remarks=po.Remarks,
                              createdAt=po.CreatedAt,
                              id=po.Id,
                          }).ToList();
            return result;
        }

        [HttpPost]
        [Route("/api/createPurchaseOrder")]
        public object createPurchaseOrder(PurchaseOrderModel purchOrderModel)
        {
            try
            {

                if (purchOrderModel.Id == 0)
                {
                    PurchaseOrder pOrder = new PurchaseOrder();
                    pOrder.PartyId = purchOrderModel.PartyId;
                    pOrder.Remarks = purchOrderModel.Remarks;
                    pOrder.DateOfInvoice = purchOrderModel.DateOfInvoice;
                    pOrder.CreatedAt = DateTime.Now.Date.ToString();
                    bMSContext.PurchaseOrder.Add(pOrder);
                    bMSContext.SaveChanges();
                    if (purchOrderModel.purcOrderDtlModel.Count() > 0)
                    {
                        for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                        {
                            PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail(); 
                            purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                            purchOrderDtl.Qty = purchOrderModel.purcOrderDtlModel[i].Qty;
                            purchOrderDtl.RecPrice = purchOrderModel.purcOrderDtlModel[i].RecPrice;
                            purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                            purchOrderDtl.OrderId = pOrder.Id;
                            purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                            purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                            purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock;
                            purchOrderDtl.RequiredPack = purchOrderModel.purcOrderDtlModel[i].RequiredPack;
                            purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                            purchOrderDtl.NetSale = purchOrderModel.purcOrderDtlModel[i].NetSale;
                            purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                            purchOrderDtl.NetSalePrice = purchOrderModel.purcOrderDtlModel[i].NetSalePrice;
                            bMSContext.PurchaseOrderDetail.Add(purchOrderDtl);
                            bMSContext.SaveChanges();
                        }
                    }
                }
                else
                {
                    var data = bMSContext.PurchaseOrder.Where(x => x.Id == purchOrderModel.Id).ToList();
                    if (data!=null) 
                    {
                        data[0].PartyId = purchOrderModel.PartyId;
                        data[0].Remarks = purchOrderModel.Remarks;
                        data[0].DateOfInvoice = purchOrderModel.DateOfInvoice;
                        data[0].CreatedAt = DateTime.Now.Date.ToString();
                        bMSContext.PurchaseOrder.Update(data[0]);
                        bMSContext.SaveChanges();
                        var dataPurDtl= bMSContext.PurchaseOrderDetail.Where(x => x.OrderId == purchOrderModel.Id).FirstOrDefault();
                        if (dataPurDtl != null) 
                        {
                            bMSContext.PurchaseOrderDetail.Remove(dataPurDtl);
                            bMSContext.SaveChanges();
                            for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                            {
                                PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail();
                                purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                                purchOrderDtl.Qty = purchOrderModel.purcOrderDtlModel[i].Qty;
                                purchOrderDtl.RecPrice = purchOrderModel.purcOrderDtlModel[i].RecPrice;
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = data[0].Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                                purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock;
                                purchOrderDtl.RequiredPack = purchOrderModel.purcOrderDtlModel[i].RequiredPack;
                                purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                purchOrderDtl.NetSale = purchOrderModel.purcOrderDtlModel[i].NetSale;
                                purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                purchOrderDtl.NetSalePrice = purchOrderModel.purcOrderDtlModel[i].NetSalePrice;
                                bMSContext.PurchaseOrderDetail.Add(purchOrderDtl);
                                bMSContext.SaveChanges();
                            }
                        }else
                        {
                            for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                            {
                                PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail();
                                purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                                purchOrderDtl.Qty = purchOrderModel.purcOrderDtlModel[i].Qty;
                                purchOrderDtl.RecPrice = purchOrderModel.purcOrderDtlModel[i].RecPrice;
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = data[0].Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                                purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock;
                                purchOrderDtl.RequiredPack = purchOrderModel.purcOrderDtlModel[i].RequiredPack;
                                purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                purchOrderDtl.NetSale = purchOrderModel.purcOrderDtlModel[i].NetSale;
                                purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                purchOrderDtl.NetSalePrice = purchOrderModel.purcOrderDtlModel[i].NetSalePrice;
                                bMSContext.PurchaseOrderDetail.Add(purchOrderDtl);
                                bMSContext.SaveChanges();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                JsonConvert.SerializeObject(new { msg = ex.Message });
            }
            return JsonConvert.SerializeObject(new { msg = "Message" });

        }

        [HttpGet]
        [Route("/api/deletePurchaseOrderById")]
        public object deletePurchaseById(int id)
        {
            try
            {
                var delpurc = bMSContext.PurchaseOrder.SingleOrDefault(u => u.Id == id);
                if (delpurc != null)
                {
                    bMSContext.PurchaseOrder.Remove(delpurc);
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
        [Route("/api/getPurchaseOrderById")]
        public IEnumerable<dynamic> getPurchaseById(int id)
        {
            var purchaseOrders = bMSContext.PurchaseOrder
              .Select(po => new
              {
                  id = po.Id,
                  partyId = po.PartyId,
                  dateOfInvoice = po.DateOfInvoice,
                  remarks = po.Remarks,
                  createdAt = po.CreatedAt
              }).Where(x=>x.id==id).ToList();

            var purchaseOrderDetails = bMSContext.PurchaseOrderDetail
                .Select(poDtl => new
                {
                    id = poDtl.Id,
                    orderId = poDtl.OrderId,
                    barCode = poDtl.BarCode,
                    itemId = poDtl.ItemId,
                    soldQty = poDtl.SoldQty,
                    rtnQty = poDtl.RtnQty,
                    netSale = poDtl.NetSale,
                    currentStock = poDtl.CurrentStock,
                    requiredPack = poDtl.RequiredPack,
                    netSalePrice = poDtl.NetSalePrice,
                    fullRate = poDtl.FullRate,
                    qty = poDtl.Qty,
                    recPrice = poDtl.RecPrice,
                    total = poDtl.Total
                }).Where(x => x.orderId == id).ToList();

            var result = new
            {
                purchaseOrders = purchaseOrders,
                purchaseOrderDetails = purchaseOrderDetails
            };

            yield return JsonConvert.SerializeObject(result);


        }

        [HttpGet]
        [Route("/api/getAllPurchaseReturn")]
        public IEnumerable<dynamic> getAllPurchaseReturn()
        {

            return bMSContext.PurchaseReturn.ToList();
        }

        [HttpPost]
        [Route("/api/createPurchaseReturn")]
        public object createPurchaseReturn(PurchaseReturnModel purchOrderModel)
        {
                try
                {

                if (purchOrderModel.Id == 0) 
                {
                    PurchaseReturn pOrder = new PurchaseReturn();
                    pOrder.OrderNo = purchOrderModel.OrderNo;
                    pOrder.Vehicle = purchOrderModel.Vehicle;
                    pOrder.PoCategroyId = purchOrderModel.PoCategroyId;
                    pOrder.GoDownId = purchOrderModel.PoCategroyId;
                    pOrder.Date = purchOrderModel.Date;
                    pOrder.StartDate = purchOrderModel.StartDate;
                    pOrder.EndDate = purchOrderModel.EndDate;
                    pOrder.ProjectionDays = purchOrderModel.ProjectionDays;
                    if (purchOrderModel.purcOrderDtlModel.Count() > 0) 
                    { 
                        for(int i=0;i<= purchOrderModel.purcOrderDtlModel.Count(); i++) 
                        {
                            PurchaseReturnDetail purchOrderDtl = new PurchaseReturnDetail();

                            purchOrderDtl.Barcode =purchOrderModel.purcOrderDtlModel[i].Barcode;
                            purchOrderDtl.ItemName =purchOrderModel.purcOrderDtlModel[i].Barcode;
                            purchOrderDtl.Quantity =purchOrderModel.purcOrderDtlModel[i].Quantity;
                            purchOrderDtl.Expiry =purchOrderModel.purcOrderDtlModel[i].Expiry;
                            purchOrderDtl.BonusQty =purchOrderModel.purcOrderDtlModel[i].BonusQty;
                            purchOrderDtl.PurchasePrice =purchOrderModel.purcOrderDtlModel[i].PurchasePrice;
                            purchOrderDtl.Discbypercent =purchOrderModel.purcOrderDtlModel[i].Discbypercent;
                            purchOrderDtl.Discbyvalue =purchOrderModel.purcOrderDtlModel[i].Discbyvalue;
                            purchOrderDtl.TotalExcTax =purchOrderModel.purcOrderDtlModel[i].TotalExcTax;
                            purchOrderDtl.Gstbypercent =purchOrderModel.purcOrderDtlModel[i].Gstbypercent;
                            purchOrderDtl.Gstbyvalue =purchOrderModel.purcOrderDtlModel[i].Gstbyvalue;
                            purchOrderDtl.TotalIncludeTax =purchOrderModel.purcOrderDtlModel[i].TotalIncludeTax;
                            purchOrderDtl.SalePrice =purchOrderModel.purcOrderDtlModel[i].SalePrice;
                            purchOrderDtl.SaleDisc =purchOrderModel.purcOrderDtlModel[i].SaleDisc;
                            purchOrderDtl.Marginbypercent =purchOrderModel.purcOrderDtlModel[i].Marginbypercent;
                            purchOrderDtl.NetRate =purchOrderModel.purcOrderDtlModel[i].NetRate;
                            purchOrderDtl.PartyName =purchOrderModel.purcOrderDtlModel[i].PartyName;
                            purchOrderDtl.Remarks =purchOrderModel.purcOrderDtlModel[i].Remarks;
                            purchOrderDtl.PartyInv =purchOrderModel.purcOrderDtlModel[i].PartyInv;
                            purchOrderDtl.Approved =purchOrderModel.purcOrderDtlModel[i].Approved;
                            purchOrderDtl.RecentPurchasePrice =purchOrderModel.purcOrderDtlModel[i].RecentPurchasePrice;
                            purchOrderDtl.TotalStock =purchOrderModel.purcOrderDtlModel[i].TotalStock;
                            purchOrderDtl.AvgPrice =purchOrderModel.purcOrderDtlModel[i].AvgPrice;
                            purchOrderDtl.DiscFlatEn =purchOrderModel.purcOrderDtlModel[i].DiscFlatEn;
                            purchOrderDtl.MiscEn =purchOrderModel.purcOrderDtlModel[i].MiscEn;
                            purchOrderDtl.RetailPrice =purchOrderModel.purcOrderDtlModel[i].RetailPrice;
                            purchOrderDtl.QtyPack =purchOrderModel.purcOrderDtlModel[i].QtyPack;
                            purchOrderDtl.LooseQty =purchOrderModel.purcOrderDtlModel[i].LooseQty;
                            purchOrderDtl.TotalQty =purchOrderModel.purcOrderDtlModel[i].TotalQty;
                            purchOrderDtl.BonusQty =purchOrderModel.purcOrderDtlModel[i].BonusQty;
                            purchOrderDtl.DescPercValue =purchOrderModel.purcOrderDtlModel[i].DescPercValue;
                            purchOrderDtl.DiscFlatValue =purchOrderModel.purcOrderDtlModel[i].DiscFlatValue;
                            purchOrderDtl.DiscFlatValue2 =purchOrderModel.purcOrderDtlModel[i].DiscFlatValue2;
                            purchOrderDtl.GstValue =purchOrderModel.purcOrderDtlModel[i].GstValue;
                            purchOrderDtl.GstValue2 =purchOrderModel.purcOrderDtlModel[i].GstValue2;
                            purchOrderDtl.TotalExecTax =purchOrderModel.purcOrderDtlModel[i].TotalExecTax;
                            purchOrderDtl.TotalIncTax =purchOrderModel.purcOrderDtlModel[i].TotalIncTax;
                            purchOrderDtl.BonusValue =purchOrderModel.purcOrderDtlModel[i].BonusValue;
                            purchOrderDtl.GrandTotal =purchOrderModel.purcOrderDtlModel[i].GrandTotal;
                            //bMSContext.PurchaseOrderDetail.Add(purchase1);
                        }
                    }
                }
                    //var Purchk = bMSContext.PurchaseOrderDetail.SingleOrDefault(u => u.Id == purchase.Id);
                    //if (Purchk != null)
                    //{

                    //    Purchk.Id = purchase.Id;
                    //    Purchk.Barcode = purchase.Barcode;
                    //    Purchk.ItemName = purchase.Barcode;
                    //    Purchk.Quantity = purchase.Quantity;
                    //    Purchk.Expiry = purchase.Expiry;
                    //    Purchk.BonusQty = purchase.BonusQty;
                    //    Purchk.PurchasePrice = purchase.PurchasePrice;
                    //    Purchk.Discbypercent = purchase.Discbypercent;
                    //    Purchk.Discbyvalue = purchase.Discbyvalue;
                    //    Purchk.TotalExcTax = purchase.TotalExcTax;
                    //    Purchk.Gstbypercent = purchase.Gstbypercent;
                    //    Purchk.Gstbyvalue = purchase.Gstbyvalue;
                    //    Purchk.TotalIncludeTax = purchase.TotalIncludeTax;
                    //    Purchk.SalePrice = purchase.SalePrice;
                    //    Purchk.SaleDisc = purchase.SaleDisc;
                    //    Purchk.Marginbypercent = purchase.Marginbypercent;
                    //    Purchk.NetRate = purchase.NetRate;
                    //    Purchk.PartyName = purchase.PartyName;
                    //    Purchk.Remarks = purchase.Remarks;
                    //    Purchk.PartyInv = purchase.PartyInv;
                    //    Purchk.Approved = purchase.Approved;
                    //    Purchk.RecentPurchasePrice = purchase.RecentPurchasePrice;
                    //    Purchk.TotalStock = purchase.TotalStock;
                    //    Purchk.AvgPrice = purchase.AvgPrice;
                    //    Purchk.DiscFlatEn = purchase.DiscFlatEn;
                    //    Purchk.MiscEn = purchase.MiscEn;
                    //    Purchk.RetailPrice = purchase.RetailPrice;
                    //    Purchk.QtyPack = purchase.QtyPack;
                    //    Purchk.LooseQty = purchase.LooseQty;
                    //    Purchk.TotalQty = purchase.TotalQty;
                    //    Purchk.BonusQty = purchase.BonusQty;
                    //    Purchk.DescPercValue = purchase.DescPercValue;
                    //    Purchk.DiscFlatValue = purchase.DiscFlatValue;
                    //    Purchk.DiscFlatValue2 = purchase.DiscFlatValue2;
                    //    Purchk.GstValue = purchase.GstValue;
                    //    Purchk.GstValue2 = purchase.GstValue2;
                    //    Purchk.TotalExecTax = purchase.TotalExecTax;
                    //    Purchk.TotalIncTax = purchase.TotalIncTax;
                    //    Purchk.BonusValue = purchase.BonusValue;
                    //    Purchk.GrandTotal = purchase.GrandTotal;
                    //    bMSContext.PurchaseOrderDetail.Update(Purchk);
                    //    bMSContext.SaveChanges();
                    //    return JsonConvert.SerializeObject(new { id = Purchk.Id });
                    //}
                    //else
                    //{
                    //PurchaseOrderDetail purchase1 = new PurchaseOrderDetail();

                    //    purchase1.Barcode = purchase.Barcode;
                    //    purchase1.ItemName = purchase.Barcode;
                    //    purchase1.Quantity = purchase.Quantity;
                    //    purchase1.Expiry = purchase.Expiry;
                    //    purchase1.BonusQty = purchase.BonusQty;
                    //    purchase1.PurchasePrice = purchase.PurchasePrice;
                    //    purchase1.Discbypercent = purchase.Discbypercent;
                    //    purchase1.Discbyvalue = purchase.Discbyvalue;
                    //    purchase1.TotalExcTax = purchase.TotalExcTax;
                    //    purchase1.Gstbypercent = purchase.Gstbypercent;
                    //    purchase1.Gstbyvalue = purchase.Gstbyvalue;
                    //    purchase1.TotalIncludeTax = purchase.TotalIncludeTax;
                    //    purchase1.SalePrice = purchase.SalePrice;
                    //    purchase1.SaleDisc = purchase.SaleDisc;
                    //    purchase1.Marginbypercent = purchase.Marginbypercent;
                    //    purchase1.NetRate = purchase.NetRate;
                    //    purchase1.PartyName = purchase.PartyName;
                    //    purchase1.Remarks = purchase.Remarks;
                    //    purchase1.PartyInv = purchase.PartyInv;
                    //    purchase1.Approved = purchase.Approved;
                    //    purchase1.RecentPurchasePrice = purchase.RecentPurchasePrice;
                    //    purchase1.TotalStock = purchase.TotalStock;
                    //    purchase1.AvgPrice = purchase.AvgPrice;
                    //    purchase1.DiscFlatEn = purchase.DiscFlatEn;
                    //    purchase1.MiscEn = purchase.MiscEn;
                    //    purchase1.RetailPrice = purchase.RetailPrice;
                    //    purchase1.QtyPack = purchase.QtyPack;
                    //    purchase1.LooseQty = purchase.LooseQty;
                    //    purchase1.TotalQty = purchase.TotalQty;
                    //    purchase1.BonusQty = purchase.BonusQty;
                    //    purchase1.DescPercValue = purchase.DescPercValue;
                    //    purchase1.DiscFlatValue = purchase.DiscFlatValue;
                    //    purchase1.DiscFlatValue2 = purchase.DiscFlatValue2;
                    //    purchase1.GstValue = purchase.GstValue;
                    //    purchase1.GstValue2 = purchase.GstValue2;
                    //    purchase1.TotalExecTax = purchase.TotalExecTax;
                    //    purchase1.TotalIncTax = purchase.TotalIncTax;
                    //    purchase1.BonusValue = purchase.BonusValue;
                    //    purchase1.GrandTotal = purchase.GrandTotal;
                    //    bMSContext.PurchaseOrderDetail.Add(purchase1);
                    //    bMSContext.SaveChanges();
                    //    return JsonConvert.SerializeObject(new { id = purchase1.Id });
                    //}
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            
        }

        [HttpGet]
        [Route("/api/deletePurchaseReturnById")]
        public object deletePurchaseReturnById(int id)
        {
            try
            {
                var delpurc = bMSContext.PurchaseReturn.SingleOrDefault(u => u.Id == id);
                if (delpurc != null)
                {
                    bMSContext.PurchaseReturn.Remove(delpurc);
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
        [Route("/api/getPurchaseReturnById")]
        public IEnumerable<PurchaseReturn> getPurchaseReturnById(int id)
        {
            return bMSContext.PurchaseReturn.Where(u => u.Id == id).ToList();
        }


        [HttpGet]
        [Route("/api/getPurchaseOrderCategory")]
        public IEnumerable<PurchaseOrderCateory> getPurchaseOrderCategory()
        {
            return bMSContext.PurchaseOrderCateory.ToList();
        }
        [HttpGet]
        [Route("/api/getGoDown")]
        public IEnumerable<GoDown> getGoDown()
        {
            return bMSContext.GoDown.ToList();
        }
    }
}
