using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Backend.Model;

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
                              invTotal = po.InvTotal,
                              disc = po.Disc,
                              endDate = po.EndDate,
                              startDate = po.StartDate,
                              zeroQty = po.ZeroQty,
                              purOrderTerm = po.PurOrderTerm
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
                    pOrder.Disc = purchOrderModel.Disc;
                    pOrder.ProjectionDays = purchOrderModel.ProjectionDays;
                    pOrder.DateOfInvoice = purchOrderModel.DateOfInvoice.ToString();
                    pOrder.EndDate = purchOrderModel.EndDate.ToString();
                    pOrder.StartDate = purchOrderModel.StartDate.ToString();
                    pOrder.InvTotal = purchOrderModel.InvTotal; 
                    pOrder.CreatedAt = DateTime.Now.Date.ToString();
                    bMSContext.PurchaseOrder.Add(pOrder);
                    bMSContext.SaveChanges();
                    if (purchOrderModel.purcOrderDtlModel.Count() > 0)
                    {
                        for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                        {
                            PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail(); 
                            purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                            purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty; 
                            purchOrderDtl.OrderId = pOrder.Id;
                            purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                            purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                            purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock; 
                            purchOrderDtl.Rate = purchOrderModel.purcOrderDtlModel[i].Rate;
                            purchOrderDtl.NetSaleQty = purchOrderModel.purcOrderDtlModel[i].NetSaleQty;
                            purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                            purchOrderDtl.RequiredQty = purchOrderModel.purcOrderDtlModel[i].RequiredQty;
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
                        data[0].Disc = purchOrderModel.Disc;
                        data[0].ProjectionDays = purchOrderModel.ProjectionDays;
                        data[0].DateOfInvoice = purchOrderModel.DateOfInvoice.ToString();
                        data[0].EndDate = purchOrderModel.EndDate.ToString();
                        data[0].StartDate = purchOrderModel.StartDate.ToString();
                        data[0].InvTotal = purchOrderModel.InvTotal;
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
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = dataPurDtl.Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                                purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock;
                                purchOrderDtl.Rate = purchOrderModel.purcOrderDtlModel[i].Rate;
                                purchOrderDtl.NetSaleQty = purchOrderModel.purcOrderDtlModel[i].NetSaleQty;
                                purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                purchOrderDtl.RequiredQty = purchOrderModel.purcOrderDtlModel[i].RequiredQty;
                                bMSContext.PurchaseOrderDetail.Add(purchOrderDtl);
                                bMSContext.SaveChanges();
                            }
                        }else
                        {
                            for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                            {
                                PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail();
                                purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = data[0].Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.BarCode = purchOrderModel.purcOrderDtlModel[i].BarCode;
                                purchOrderDtl.CurrentStock = purchOrderModel.purcOrderDtlModel[i].CurrentStock;
                                purchOrderDtl.Rate = purchOrderModel.purcOrderDtlModel[i].Rate;
                                purchOrderDtl.NetSaleQty = purchOrderModel.purcOrderDtlModel[i].NetSaleQty;
                                purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                purchOrderDtl.RequiredQty = purchOrderModel.purcOrderDtlModel[i].RequiredQty;
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
                  startDate = po.StartDate,
                  endDate = po.EndDate,
                  remarks = po.Remarks,
                  projectionDays = po.ProjectionDays,
                  disc = po.Disc,
                  invTotal = po.InvTotal,
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
                    netSaleQty = poDtl.NetSaleQty,
                    currentStock = poDtl.CurrentStock,
                    requiredQty = poDtl.RequiredQty, 
                    rate = poDtl.Rate,
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

            var result = (from po in bMSContext.PurchaseReturn
                          join p in bMSContext.Party on po.PartyId equals p.Id
                          select new
                          {
                              partyId = p.PartyName,
                              date = po.Date,
                              avgPrice = po.AvgPrice,
                              qtyPack = po.QtyPack,
                              bonusQty = po.BonusQty,
                              purSno = po.PurSno,
                              grandTotal = po.GrandTotal,
                              totalStock = po.TotalStock,
                              totalQty = po.TotalQty,
                              userId = po.UserId,
                              id = po.Id,
                              disc=po.Disc,
                              flatDisc=po.FlatDisc,
                              itemType=po.ItemType
                          }).ToList();
            return result;
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
                        pOrder.AvgPrice = purchOrderModel.AvgPrice;
                        pOrder.PartyId = purchOrderModel.PartyId;
                        pOrder.UserId = purchOrderModel.UserId;
                        pOrder.Date = DateTime.Now.Date.ToString();
                        pOrder.BonusQty = purchOrderModel.BonusQty;
                        pOrder.LooseQty = purchOrderModel.LooseQty;
                        pOrder.QtyPack = purchOrderModel.QtyPack;
                        pOrder.TotalExcTax = purchOrderModel.TotalExcTax;
                        pOrder.TotalIncTax = purchOrderModel.TotalIncTax;
                        pOrder.TotalQty = purchOrderModel.TotalQty;
                        pOrder.BonusQty = purchOrderModel.BonusQty;
                        pOrder.Total = purchOrderModel.GrandTotal;
                        pOrder.GrandTotal = purchOrderModel.GrandTotal;
                        pOrder.ItemType = purchOrderModel.ItemType;
                        pOrder.Disc = purchOrderModel.Disc;
                        bMSContext.PurchaseReturn.Add(pOrder);
                        bMSContext.SaveChanges();
                        if (purchOrderModel.purcOrderDtlModel.Count() > 0) 
                        { 
                            for(int i=0;i<= purchOrderModel.purcOrderDtlModel.Count(); i++) 
                            {
                                PurchaseReturnDetail purchOrderDtl = new PurchaseReturnDetail(); 
                                purchOrderDtl.Barcode =purchOrderModel.purcOrderDtlModel[i].Barcode;
                                purchOrderDtl.OrderReturnId = pOrder.Id;
                                purchOrderDtl.ItemId =purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.Qty = purchOrderModel.purcOrderDtlModel[i].Qty;
                                purchOrderDtl.Disc = purchOrderModel.purcOrderDtlModel[i].Disc;
                                purchOrderDtl.FlatDisc = purchOrderModel.purcOrderDtlModel[i].FlatDisc;
                                purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                bMSContext.PurchaseReturnDetail.Add(purchOrderDtl);
                                bMSContext.SaveChanges();
                            }
                        }
                    }
                    else 
                    {
                        var data = bMSContext.PurchaseReturn.Where(x => x.Id == purchOrderModel.Id).FirstOrDefault();
                        if (data != null) 
                        {
                            data.Id = purchOrderModel.Id;
                            data.OrderNo = purchOrderModel.OrderNo;
                            data.AvgPrice = purchOrderModel.AvgPrice;
                            data.PartyId = purchOrderModel.PartyId;
                            data.UserId = purchOrderModel.UserId;
                            data.Date = DateTime.Now.Date.ToString();
                            data.BonusQty = purchOrderModel.BonusQty;
                            data.LooseQty = purchOrderModel.LooseQty;
                            data.QtyPack = purchOrderModel.QtyPack;
                            data.TotalExcTax = purchOrderModel.TotalExcTax;
                            data.TotalIncTax = purchOrderModel.TotalIncTax;
                            data.TotalQty = purchOrderModel.TotalQty;
                            data.BonusQty = purchOrderModel.BonusQty;
                            data.Total = purchOrderModel.GrandTotal;
                            data.GrandTotal = purchOrderModel.GrandTotal;
                            data.Disc = purchOrderModel.Disc;
                            data.FlatDisc = purchOrderModel.flatDisc;
                            bMSContext.PurchaseReturn.Update(data);
                            bMSContext.SaveChanges();
                        var dataPurcReturnDtl = bMSContext.PurchaseReturnDetail.Where(x => x.OrderReturnId == data.Id).ToList();
                        if (dataPurcReturnDtl != null) 
                        {
                            foreach (var item in dataPurcReturnDtl)
                            {
                                bMSContext.PurchaseReturnDetail.Remove(item);
                                bMSContext.SaveChanges();
                            }
                            if (purchOrderModel.purcOrderDtlModel.Count() > 0)
                            {
                                for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                                {
                                    PurchaseReturnDetail purchOrderDtl = new PurchaseReturnDetail();
                                    purchOrderDtl.Barcode = purchOrderModel.purcOrderDtlModel[i].Barcode;
                                    purchOrderDtl.OrderReturnId = data.Id;
                                    purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                    purchOrderDtl.Qty = purchOrderModel.purcOrderDtlModel[i].Qty;
                                    purchOrderDtl.Disc = purchOrderModel.purcOrderDtlModel[i].Disc;
                                    purchOrderDtl.FlatDisc = purchOrderModel.purcOrderDtlModel[i].FlatDisc;
                                    purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                    purchOrderDtl.Total = purchOrderModel.purcOrderDtlModel[i].Total;
                                    purchOrderDtl.FullRate = purchOrderModel.purcOrderDtlModel[i].FullRate;
                                    bMSContext.PurchaseReturnDetail.Add(purchOrderDtl);
                                    bMSContext.SaveChanges();
                                }
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
        public IEnumerable<dynamic> getPurchaseReturnById(int id)
        {
               var purchaseOrders = bMSContext.PurchaseReturn
              .Select(po => new
              {
                  id = po.Id,
                  partyId = po.PartyId,
                  totalIncTax = po.TotalIncTax,
                  totalExcTax = po.TotalExcTax,
                  total = po.Total,
                  totalQty = po.TotalQty,
                  qtyPack = po.QtyPack,
                  avgPrice = po.AvgPrice,
                  bonusQty = po.BonusQty,
                  grandTotal = po.GrandTotal,
                  looseQty = po.LooseQty,
                  orderNo = po.OrderNo, 
                  totalStock = po.TotalStock,
                  userId = po.UserId,
              }).Where(x => x.id == id).ToList();
                        var purchaseOrderDetails = bMSContext.PurchaseReturnDetail
                            .Select(poDtl => new
                            {
                                id = poDtl.Id,
                                orderReturnId = poDtl.OrderReturnId,
                                barcode = poDtl.Barcode,
                                itemId = poDtl.ItemId,
                                qty = poDtl.Qty,
                                total = poDtl.Total,
                                fullRate = poDtl.FullRate,
                                disc = poDtl.Disc,
                                flatDisc = poDtl.FlatDisc, 

                            }).Where(x => x.orderReturnId == id).ToList();

                        var result = new
                        {
                            purchaseOrders = purchaseOrders,
                            purchaseOrderDetails = purchaseOrderDetails
                        };

            yield return JsonConvert.SerializeObject(result);
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
