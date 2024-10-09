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
        [Route("/api/getItemDetailbyBarCode")]
        public IEnumerable<Item> getItemDetailbyBarCode(string barCode)
        {
            return bMSContext.Item.Where(u => u.AliasName == barCode).ToList();
        }

        [HttpPost]
        [Route("/api/createPurchase")]
        public object CreateOrUpdatePurchase(PurchaseModel purchModel)
        {
            try
            {
                if (purchModel.Id == 0)
                {
                    Purchase purchase = new Purchase
                    {
                        VendorId = purchModel.VendorId,
                        Remarks = purchModel.Remarks,
                        InvoiceNo = purchModel.InvoiceNo,
                        RecentPurchasePrice = purchModel.RecentPurchasePrice,
                        SalePrice = purchModel.SalePrice,
                        ItemsQuantity = purchModel.ItemsQuantity,
                        TotalDiscount = purchModel.TotalDiscount,
                        TotalGst = purchModel.TotalGst,
                        BillTotal = purchModel.BillTotal,
                        CreatedAt = DateTime.Now,
                        CreatedBy = purchModel.CreatedBy,
                    };
                    bMSContext.Purchase.Add(purchase);
                    bMSContext.SaveChanges();
                    if (purchModel.PurchaseDetailModel != null && purchModel.PurchaseDetailModel.Any())
                    {
                        foreach (var detail in purchModel.PurchaseDetailModel)
                        {
                            PurchaseDetail purchDetail = new PurchaseDetail
                            {
                                PurchaseId = purchase.Id,
                                Barcode = detail.Barcode,
                                ItemId = detail.ItemId,
                                Quantity = detail.Quantity,
                                BonusQuantity = detail.BonusQuantity,
                                PurchasePrice = detail.PurchasePrice,
                                DiscountByPercent = detail.DiscountByPercent,
                                DiscountByValue = detail.DiscountByValue,
                                Total = detail.Total,
                                GstByPercent = detail.GstByPercent,
                                GstByValue = detail.GstByValue,
                                TotalWithGst = detail.TotalWithGst,
                                NetRate = detail.NetRate,
                                MarginPercent = detail.MarginPercent,
                                SalePrice = detail.SalePrice,
                                SaleDiscountByValue = detail.SaleDiscountByValue,
                                NetSalePrice = detail.NetSalePrice,
                                CreatedAt = DateTime.Now,
                                CreatedBy = detail.CreatedBy,
                            };
                            bMSContext.PurchaseDetail.Add(purchDetail);
                        }
                        bMSContext.SaveChanges();
                    }
                }
                else
                {
                    // Update existing Purchase order
                    var existingPurchase = bMSContext.Purchase.FirstOrDefault(x => x.Id == purchModel.Id);
                    if (existingPurchase != null)
                    {
                        existingPurchase.VendorId = purchModel.VendorId;
                        existingPurchase.Remarks = purchModel.Remarks;
                        existingPurchase.InvoiceNo = purchModel.InvoiceNo;
                        existingPurchase.RecentPurchasePrice = purchModel.RecentPurchasePrice;
                        existingPurchase.SalePrice = purchModel.SalePrice;
                        existingPurchase.ItemsQuantity = purchModel.ItemsQuantity;
                        existingPurchase.TotalDiscount = purchModel.TotalDiscount;
                        existingPurchase.TotalGst = purchModel.TotalGst;
                        existingPurchase.BillTotal = purchModel.BillTotal;
                        existingPurchase.UpdatedAt = DateTime.Now;
                        existingPurchase.UpdatedBy = purchModel.CreatedBy;
                        bMSContext.Purchase.Update(existingPurchase);
                        bMSContext.SaveChanges();

                        // Update Purchase Details
                        var existingDetails = bMSContext.PurchaseDetail.Where(x => x.PurchaseId == existingPurchase.Id).ToList();
                        bMSContext.PurchaseDetail.RemoveRange(existingDetails);
                        bMSContext.SaveChanges();

                        if (purchModel.PurchaseDetailModel != null && purchModel.PurchaseDetailModel.Any())
                        {
                            foreach (var detail in purchModel.PurchaseDetailModel)
                            {
                                PurchaseDetail purchDetail = new PurchaseDetail
                                {
                                    PurchaseId = existingPurchase.Id,
                                    Barcode = detail.Barcode,
                                    ItemId = detail.ItemId,
                                    Quantity = detail.Quantity,
                                    BonusQuantity = detail.BonusQuantity,
                                    PurchasePrice = detail.PurchasePrice,
                                    DiscountByPercent = detail.DiscountByPercent,
                                    DiscountByValue = detail.DiscountByValue,
                                    Total = detail.Total,
                                    GstByPercent = detail.GstByPercent,
                                    GstByValue = detail.GstByValue,
                                    TotalWithGst = detail.TotalWithGst,
                                    NetRate = detail.NetRate,
                                    MarginPercent = detail.MarginPercent,
                                    SalePrice = detail.SalePrice,
                                    SaleDiscountByValue = detail.SaleDiscountByValue,
                                    NetSalePrice = detail.NetSalePrice,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = detail.CreatedBy
                                };
                                bMSContext.PurchaseDetail.Add(purchDetail);
                            }
                            bMSContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { msg = ex.Message });
            }
            return JsonConvert.SerializeObject(new { msg = "Purchase Order processed successfully" });
        }
        [HttpGet]
        [Route("/api/getAllPurchases")]
        public IEnumerable<dynamic> getAllPurchase()
        {
            var result = (from purchase in bMSContext.Purchase
                          join Party in bMSContext.Party on purchase.VendorId equals Party.Id
                          select new
                          {
                              purchaseId = purchase.Id,
                              vendorId = Party.PartyName,
                              invoiceNo = purchase.InvoiceNo,
                              remarks = purchase.Remarks,
                              recentPurchasePrice = purchase.RecentPurchasePrice,
                              salePrice = purchase.SalePrice,
                              itemsQuantity = purchase.ItemsQuantity,
                              totalDiscount = purchase.TotalDiscount,
                              totalGst = purchase.TotalGst,
                              billTotal = purchase.BillTotal,
                              CreatedBy = purchase.CreatedBy
                          }).ToList();

            return result;

        }
        [HttpGet]
        [Route("/api/getPurchaseById")]
        public IEnumerable<dynamic> getPurchaseById(int id)
        {
            // Query to fetch data from Purchase table
            var purchase = bMSContext.Purchase
                .Select(p => new
                {
                    id = p.Id,
                    vendorId = p.VendorId,
                    invoiceNo = p.InvoiceNo,
                    remarks = p.Remarks,
                    recentPurchasePrice = p.RecentPurchasePrice,
                    salePrice = p.SalePrice,
                    itemsQuantity = p.ItemsQuantity,
                    totalDiscount = p.TotalDiscount,
                    totalGst = p.TotalGst,
                    billTotal = p.BillTotal
                   
                })
                .Where(x => x.id == id)
                .ToList();

            // Query to fetch data from PurchaseDetail table
            var purchaseDetails = bMSContext.PurchaseDetail
                .Select(pDtl => new
                {
                    id = pDtl.Id,
                    purchaseId = pDtl.PurchaseId,
                    barcode = pDtl.Barcode,
                    ItemId = pDtl.ItemId,
                    quantity = pDtl.Quantity,
                    bonusQuantity = pDtl.BonusQuantity,
                    purchasePrice = pDtl.PurchasePrice,
                    discountByPercent = pDtl.DiscountByPercent,
                    discountByValue = pDtl.DiscountByValue,
                    total = pDtl.Total,
                    gstByPercent = pDtl.GstByPercent,
                    gstByValue = pDtl.GstByValue,
                    totalWithGst = pDtl.TotalWithGst,
                    netRate = pDtl.NetRate,
                    marginPercent = pDtl.MarginPercent,
                    salePriceDetail = pDtl.SalePrice,
                    saleDiscountByValue = pDtl.SaleDiscountByValue,
                    netSalePrice = pDtl.NetSalePrice
                })
                .Where(x => x.purchaseId == id)
                .ToList();

            // Combine the results
            var result = new
            {
                purchase = purchase,
                purchaseDetails = purchaseDetails
            };

            yield return JsonConvert.SerializeObject(result);
        }
        [HttpGet]
        [Route("/api/deletePurchaseById")]
        public object deletePurchaseById(int id)
        {
            try
            { 
                var delPurchase = bMSContext.Purchase.SingleOrDefault(p => p.Id == id);
                if (delPurchase != null)
                { 
                    var delPurchaseDetails = bMSContext.PurchaseDetail.Where(pDtl => pDtl.PurchaseId == id).ToList(); 
                    if (delPurchaseDetails.Any())
                    {
                        bMSContext.PurchaseDetail.RemoveRange(delPurchaseDetails);
                    } 
                    bMSContext.Purchase.Remove(delPurchase); 
                    bMSContext.SaveChanges(); 
                    return JsonConvert.SerializeObject(new { id = delPurchase.Id });
                }
            }
            catch (Exception ex)
            { 
                return null;
            } 
            return null;
        }

        [HttpGet]
        [Route("/api/getAllPurchaseOrder")]
        public IEnumerable<dynamic> getAllPurchaseOrder()
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
                    pOrder.CreatedBy = purchOrderModel.Createdby;
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
                            purchOrderDtl.CreatedAt = DateTime.Now;
                            purchOrderDtl.CreatedBy = purchOrderModel.Createdby;
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
                        data[0].UpdatedAt = DateTime.Now;
                        data[0].UpdatedBy = purchOrderModel.Updatedby;
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
                                purchOrderDtl.CreatedAt = DateTime.Now;
                                purchOrderDtl.CreatedBy = purchOrderModel.Createdby;
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
                                purchOrderDtl.CreatedAt = DateTime.Now;
                                purchOrderDtl.CreatedBy = purchOrderModel.Createdby;
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
        public object deletePurchaseOrderById(int id)
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
        public IEnumerable<dynamic> getPurchaseOrderById(int id)
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
                        pOrder.CreatedAt = DateTime.Now;
                        pOrder.CreatedBy = purchOrderModel.Createdby;
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
                                purchOrderDtl.CreatedAt = DateTime.Now;
                                purchOrderDtl.CreatedBy = purchOrderModel.Createdby;
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
                            data.UpdatedAt = DateTime.Now;
                            data.UpdatedBy = purchOrderModel.Updatedby;
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
                                    purchOrderDtl.CreatedAt = DateTime.Now;
                                    purchOrderDtl.CreatedBy = purchOrderModel.Createdby;
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
