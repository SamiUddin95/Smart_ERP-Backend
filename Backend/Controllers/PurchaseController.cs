﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Backend.Model;
using System.Numerics;
using System.Globalization;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PurchaseController
    {

        ERPContext bMSContext = new ERPContext();
        public class PostPurchaseItemDto
        {
            public string BarCode { get; set; }
            public double? CurrentStock { get; set; }
            public double? LastNetSalePrice { get; set; }
            public double? LastNetCost { get; set; }
            public double? PurchasePrice { get; set; }
            public double? saleDiscountByValue { get; set; }
            public double? SalePrice { get; set; }
            public double? SaleDisc { get; set; }
            public double? NetSalePrice { get; set; }

        }
        [HttpGet]
        [Route("/api/getPurchaseMaxSerialNo")]
        public int getAllMaxSerialNo()
        {
            return bMSContext.Purchase.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
        }
        [HttpGet]
        [Route("/api/getPurchaseReturnMaxSerialNo")]
        public long getPurchaseReturnMaxSerialNo()
        {
            return bMSContext.PurchaseReturn.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
        }
        [HttpGet]
        [Route("/api/getItemDetailbyBarCode")]
        public IEnumerable<dynamic> getItemDetailbyBarCode(string barCode)
        {
            var item= bMSContext.Item.Where(u => u.AliasName == barCode).ToList();
            if (item.Count()>0)
                return item; 
            var altItem = bMSContext.AlternateItem.Where(u => u.Barcode == barCode).ToList();
            if(altItem.Count()>0)
                return altItem;
            var childItem = bMSContext.ChildItem.Where(u => u.Barcode == barCode).ToList();
            if(childItem.Count()>0)
                return childItem;

            return null;

        }

        [HttpGet]
        [Route("/api/getPurchaseDetailbyBarCode")]
        public IEnumerable<dynamic> getPurchaseDetailbyBarCode(string barCode)
        {
            var result = (from i in bMSContext.Item
                          join pd in bMSContext.PurchaseDetail
                          on i.AliasName equals pd.Barcode
                          where pd.Barcode == barCode
                          select new
                          {
                              pd.NetQuantity,
                              pd.SalePrice,
                              Item = i,
                              PurchaseDetail = pd
                          }).ToList();
            //var item = bMSContext.Item.Where(u => u.AliasName == barCode).ToList();
            if (result.Count() > 0)
                return result;
            var altItem = bMSContext.AlternateItem.Where(u => u.Barcode == barCode).ToList();
            if (altItem.Count() > 0)
                return altItem;
            var childItem = bMSContext.ChildItem.Where(u => u.Barcode == barCode).ToList();
            if (childItem.Count() > 0)
                return childItem;


            return null;

        }


        [HttpGet]
        [Route("/api/getAllItemDetailbyBarCode")]
        public IEnumerable<dynamic> getAllItemDetailbyBarCode(string barCode)
        {
            var items = bMSContext.Item
                        .Where(u => u.ItemName.Contains(barCode))
                        .Select(u => new PurchaseItemSearchModel { barCode=u.AliasName,itemName = u.ItemName,salePrice=Convert.ToDecimal(u.SalePrice),purchasePrice=Convert.ToDecimal(u.PurchasePrice) })
                        .ToList(); 
            var altItems = bMSContext.AlternateItem
                        .Where(u => u.AlternateItemName.Contains(barCode))
                        .Select(u => new PurchaseItemSearchModel { barCode = u.Barcode, itemName = u.AlternateItemName })
                        .ToList(); 
            var childItems = bMSContext.ChildItem
                        .Where(u => u.ChildName.Contains(barCode))
                        .Select(u => new PurchaseItemSearchModel { barCode = u.Barcode, itemName = u.ChildName})
                        .ToList(); 
            var allItems = items
                .Concat(altItems)
                .Concat(childItems)
                .ToList();
            return allItems;


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
                        SalePrice = purchModel.SalePrice,
                        TotalDiscount = purchModel.TotalDiscount,
                        TotalGst = purchModel.TotalGst,
                        BillTotal = purchModel.BillTotal,
                        NetSaleTotal = purchModel.netSaleTotal,
                        NetCostTotal = purchModel.netCostTotal,
                        NetQuantity = purchModel.NetQuantity,
                        TotalDisc = purchModel.TotalDisc,
                        NetProfitInValue = purchModel.netProfitInValue,
                        CreatedAt = DateTime.Now.Date,
                        CreatedBy = purchModel.CreatedBy,
                        UpdatedAt = DateTime.Now.Date,
                        PostedDate = DateTime.Now.Date,
                        UpdatedBy = purchModel.UpdatedBy,
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
                                ItemName = detail.ItemName,
                                Quantity = detail.Quantity,
                                BonusQuantity = detail.BonusQuantity,
                                PurchasePrice = detail.PurchasePrice,
                                DiscountByPercent = detail.DiscountByPercent,
                                DiscountByValue = detail.DiscountByValue,
                                GstByPercent = detail.GstByPercent,
                                GstByValue = detail.GstByValue,
                                TotalIncDisc = detail.TotalIncDisc,
                                TotalIncGst = detail.TotalIncGst,
                                NetSaleTotal = detail.NetSaleTotal,
                                NetRate = detail.NetRate,
                                NetQuantity = detail.NetQuantity,
                                SubTotal = detail.SubTotal,
                                MarginPercent = detail.MarginPercent,
                                SalePrice = detail.SalePrice,
                                SaleDiscountByValue = detail.SaleDiscountByValue,
                                NetSalePrice = detail.NetSalePrice,
                                TotalSalePrice = detail.TotalSalePrice,
                                CreatedAt = DateTime.Now,
                                CreatedBy = detail.CreatedBy
                            };
                            bMSContext.PurchaseDetail.Add(purchDetail);
                        }
                    }
                    bMSContext.SaveChanges();
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
                        existingPurchase.SalePrice = purchModel.SalePrice;
                        existingPurchase.TotalDiscount = purchModel.TotalDiscount;
                        existingPurchase.TotalGst = purchModel.TotalGst;
                        existingPurchase.BillTotal = purchModel.BillTotal;
                        existingPurchase.NetSaleTotal = purchModel.netSaleTotal;
                        existingPurchase.NetCostTotal = purchModel.netCostTotal;
                        existingPurchase.NetQuantity = purchModel.NetQuantity;
                        existingPurchase.TotalDisc = purchModel.TotalDisc;
                        existingPurchase.NetProfitInValue = purchModel.netProfitInValue;
                        existingPurchase.UpdatedAt = DateTime.Now.Date;
                        existingPurchase.PostedDate = DateTime.Now.Date;
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
                                    ItemName = detail.ItemName,
                                    Quantity = detail.Quantity,
                                    BonusQuantity = detail.BonusQuantity,
                                    PurchasePrice = detail.PurchasePrice,
                                    DiscountByPercent = detail.DiscountByPercent,
                                    DiscountByValue = detail.DiscountByValue,
                                    GstByPercent = detail.GstByPercent,
                                    GstByValue = detail.GstByValue, 
                                    TotalIncDisc = detail.TotalIncDisc,
                                    TotalIncGst = detail.TotalIncGst,
                                    NetSaleTotal = detail.NetSaleTotal,
                                    NetRate = detail.NetRate,
                                    NetQuantity = detail.NetQuantity,
                                    SubTotal = detail.SubTotal,
                                    MarginPercent = detail.MarginPercent,
                                    SalePrice = detail.SalePrice,
                                    SaleDiscountByValue = detail.SaleDiscountByValue,
                                    NetSalePrice = detail.NetSalePrice,
                                    TotalSalePrice = detail.TotalSalePrice,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = detail.CreatedBy
                                };
                                bMSContext.PurchaseDetail.Add(purchDetail);
                                bMSContext.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { msg = ex.Message });
            }
            return JsonConvert.SerializeObject(new { msg = "Purchase processed successfully" });
        }

        [HttpPost]
        [Route("/api/postPurchaseNew")]

        public object PostPurchaseNew(int purchaseId, string postedBy, [FromBody] List<PostPurchaseItemDto> items)
        {
            try
            {
                var postedDate = bMSContext.Purchase.FirstOrDefault(x => x.Id == purchaseId);
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = postedBy;
                    postedDate.PostUnpostStatus = "Y";
                    bMSContext.Purchase.Update(postedDate);
                    bMSContext.SaveChanges();
                }

                foreach (var item in items)
                {
                    var itemDtl = bMSContext.Item.FirstOrDefault(x => x.AliasName == item.BarCode);
                    if (itemDtl != null)
                    {
                        itemDtl.CurrentStock = Convert.ToInt16(Math.Floor(item.CurrentStock ?? 0));
                        itemDtl.PurchasePrice = Convert.ToInt16(Math.Floor(item.PurchasePrice ?? 0));
                        itemDtl.SalePrice = Convert.ToInt16(Math.Floor(item.SalePrice ?? 0));
                        itemDtl.Discflat = Convert.ToInt16(Math.Floor(item.saleDiscountByValue ?? 0));
                        itemDtl.NetSalePrice = Convert.ToInt16(Math.Floor(item.NetSalePrice ?? 0));
                        bMSContext.Item.Update(itemDtl);
                        bMSContext.SaveChanges();
                    }
                }

                return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
            }
        }



        [HttpPost]
        [Route("/api/postPurchase")]
        public object postPurchase(int purchaseId, string postedBy, string barCodes, string currentStock, string lastNetSalePrice,
            string lastNetCost, string saleDisc, string netSaleePrice)
        {
            try
            {
                string[] barCodeArray = (barCodes ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
                string[] currentStockArray = (currentStock ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
                string[] lastNetSalePriceArray = (lastNetSalePrice ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
                string[] lastNetCostArray = (lastNetCost ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
                string[] saleDiscArray = (saleDisc ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);
                string[] netSalePriceArray = (netSaleePrice ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries);

                int length = new int[] { barCodeArray.Length,
                    currentStockArray.Length,lastNetSalePriceArray.Length,lastNetCostArray.Length,
                    saleDiscArray.Length, netSalePriceArray.Length
                    }.Min();
                var postedDate = bMSContext.Purchase.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = postedBy;
                    postedDate.PostUnpostStatus = "Y";
                    bMSContext.Purchase.Update(postedDate);
                    bMSContext.SaveChanges();
                }
                for (int i = 0; i < length; i++)
                {
                    var barcode = barCodeArray[i];
                    var stock = (int)Math.Floor(double.Parse(currentStockArray[i]));
                    var salePrice = (int)Math.Floor(double.Parse(lastNetSalePriceArray[i]));
                    var cost = (int)Math.Floor(double.Parse(lastNetCostArray[i]));
                    var disc = (int)Math.Floor(double.Parse(saleDiscArray[i]));
                    var netSalePrice = (int)Math.Floor(double.Parse(netSalePriceArray[i]));


                    var itemDtl = bMSContext.Item.Where(x => x.AliasName == barcode).FirstOrDefault();
                    if (itemDtl != null)
                    {
                        itemDtl.CurrentStock = Convert.ToInt16(stock);
                        itemDtl.PurchasePrice = Convert.ToInt16(cost);
                        itemDtl.SalePrice = Convert.ToInt16(salePrice);
                        itemDtl.Discflat = Convert.ToInt16(saleDisc);
                        itemDtl.NetSalePrice = Convert.ToInt16(netSalePrice);
                        bMSContext.Item.Update(itemDtl);
                        bMSContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            { }
            return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
        }

        [HttpGet]
        [Route("/api/unPostPurchase")]
        public object unPostPurchase(int purchaseId, string postedBy, string barCodes, string currentStock, string lastNetSalePrice,
            string lastNetCost, string saleDisc, string netSaleePrice)
        {
            try
            {
                string[] barCodeArray = barCodes.Split(',');
                string[] currentStockArray = currentStock.Split(',');
                string[] lastNetSalePriceArray = lastNetSalePrice.Split(',');
                string[] lastNetCostArray = lastNetCost.Split(',');
                string[] saleDiscArray = saleDisc.Split(',');
                string[] netSalePriceArray = netSaleePrice.Split(',');
                int length = new int[] { barCodeArray.Length,
                    currentStockArray.Length,lastNetSalePriceArray.Length,lastNetCostArray.Length,
                    saleDiscArray.Length, netSalePriceArray.Length
                    }.Min();
                var postedDate = bMSContext.Purchase.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = null;
                    postedDate.PostUnpostStatus = "N";
                    bMSContext.Purchase.Update(postedDate);
                    bMSContext.SaveChanges();
                }
                for (int i = 0; i < length; i++)
                {
                    var barcode = barCodeArray[i];
                    var stock = (int)Math.Floor(double.Parse(currentStockArray[i]));
                    var salePrice = (int)Math.Floor(double.Parse(lastNetSalePriceArray[i]));
                    var cost = (int)Math.Floor(double.Parse(lastNetCostArray[i]));
                    var disc = (int)Math.Floor(double.Parse(saleDiscArray[i]));
                    var netSalePrice = (int)Math.Floor(double.Parse(netSalePriceArray[i]));


                    var itemDtl = bMSContext.Item.Where(x => x.AliasName == barcode).FirstOrDefault();
                    if (itemDtl != null)
                    {
                        itemDtl.CurrentStock = Convert.ToInt16(stock);
                        itemDtl.PurchasePrice = Convert.ToInt16(cost);
                        itemDtl.SalePrice = Convert.ToInt16(salePrice);
                        itemDtl.Discflat = Convert.ToInt16(saleDisc);
                        itemDtl.NetSalePrice = Convert.ToInt16(netSalePrice);
                        bMSContext.Item.Update(itemDtl);
                        bMSContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            { }
            return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Un Posted successfully" });
        }

        [HttpGet]
        [Route("/api/postPurchaseReturn")]
        public object postPurchaseReturn(int purchaseId, string postedBy, string barCodes, string currentStock, string lastNetSalePrice,
    string lastNetCost, string saleDisc, string netSaleePrice)
        {
            try
            {
                string[] barCodeArray = barCodes.Split(',');
                string[] currentStockArray = currentStock.Split(',');
                string[] lastNetSalePriceArray = lastNetSalePrice.Split(',');
                string[] lastNetCostArray = lastNetCost.Split(',');
                string[] saleDiscArray = saleDisc.Split(',');
                string[] netSalePriceArray = netSaleePrice.Split(',');
                int length = new int[] { barCodeArray.Length,
                    currentStockArray.Length,lastNetSalePriceArray.Length,lastNetCostArray.Length,
                    saleDiscArray.Length, netSalePriceArray.Length
                    }.Min();
                var postedDate = bMSContext.PurchaseReturn.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = postedBy;
                    postedDate.PostUnpostStatus = "N";
                    bMSContext.PurchaseReturn.Update(postedDate);
                    bMSContext.SaveChanges();
                }
                for (int i = 0; i < length; i++)
                {
                    var barcode = barCodeArray[i];
                    var stock = (int)Math.Floor(double.Parse(currentStockArray[i]));
                    var salePrice = (int)Math.Floor(double.Parse(lastNetSalePriceArray[i]));
                    var cost = (int)Math.Floor(double.Parse(lastNetCostArray[i]));
                    var disc = (int)Math.Floor(double.Parse(saleDiscArray[i]));
                    var netSalePrice = (int)Math.Floor(double.Parse(netSalePriceArray[i]));


                    var itemDtl = bMSContext.Item.Where(x => x.AliasName == barcode).FirstOrDefault();
                    if (itemDtl != null)
                    {
                        itemDtl.CurrentStock = Convert.ToInt16(stock);
                        itemDtl.PurchasePrice = Convert.ToInt16(cost);
                        itemDtl.SalePrice = Convert.ToInt16(salePrice);
                        itemDtl.Discflat = Convert.ToInt16(saleDisc);
                        itemDtl.NetSalePrice = Convert.ToInt16(netSalePrice);
                        bMSContext.Item.Update(itemDtl);
                        bMSContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            { }
            return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
        }

        [HttpGet]
        [Route("/api/unPostPurchaseReturn")]
        public object unPostPurchaseReturn(int purchaseId, string postedBy, string barCodes, string currentStock, string lastNetSalePrice,
            string lastNetCost, string saleDisc, string netSaleePrice)
        {
            try
            {
                string[] barCodeArray = barCodes.Split(',');
                string[] currentStockArray = currentStock.Split(',');
                string[] lastNetSalePriceArray = lastNetSalePrice.Split(',');
                string[] lastNetCostArray = lastNetCost.Split(',');
                string[] saleDiscArray = saleDisc.Split(',');
                string[] netSalePriceArray = netSaleePrice.Split(',');
                int length = new int[] { barCodeArray.Length,
                    currentStockArray.Length,lastNetSalePriceArray.Length,lastNetCostArray.Length,
                    saleDiscArray.Length, netSalePriceArray.Length
                    }.Min();
                var postedDate = bMSContext.Purchase.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = null;
                    postedDate.PostUnpostStatus = "N";
                    bMSContext.Purchase.Update(postedDate);
                    bMSContext.SaveChanges();
                }
                for (int i = 0; i < length; i++)
                {
                    var barcode = barCodeArray[i];
                    var stock = (int)Math.Floor(double.Parse(currentStockArray[i]));
                    var salePrice = (int)Math.Floor(double.Parse(lastNetSalePriceArray[i]));
                    var cost = (int)Math.Floor(double.Parse(lastNetCostArray[i]));
                    var disc = (int)Math.Floor(double.Parse(saleDiscArray[i]));
                    var netSalePrice = (int)Math.Floor(double.Parse(netSalePriceArray[i]));


                    var itemDtl = bMSContext.Item.Where(x => x.AliasName == barcode).FirstOrDefault();
                    if (itemDtl != null)
                    {
                        itemDtl.CurrentStock = Convert.ToInt16(stock);
                        itemDtl.PurchasePrice = Convert.ToInt16(cost);
                        itemDtl.SalePrice = Convert.ToInt16(salePrice);
                        itemDtl.Discflat = Convert.ToInt16(saleDisc);
                        itemDtl.NetSalePrice = Convert.ToInt16(netSalePrice);
                        bMSContext.Item.Update(itemDtl);
                        bMSContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            { }
            return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
        }

        [HttpGet]
        [Route("/api/getAllPurchases")]
        public IEnumerable<dynamic> getAllPurchase(string dateFrom, string dateTo, string postedDate, string postedBy, int partyId, string invNo)
        {
            DateTime? dateFromParsed = null;
            DateTime? dateToParsed = null;
            DateTime? postedDateParsed = null;

            if (!string.IsNullOrEmpty(dateFrom) && DateTime.TryParse(dateFrom, out DateTime parsedDateFrom))
            {
                dateFromParsed = parsedDateFrom;
            }

            if (!string.IsNullOrEmpty(dateTo) && DateTime.TryParse(dateTo, out DateTime parsedDateTo))
            {
                dateToParsed = parsedDateTo;
            }

            if (!string.IsNullOrEmpty(postedDate) && DateTime.TryParse(postedDate, out DateTime parsedPostedDate))
            {
                postedDateParsed = parsedPostedDate;
            }

            var result = (from purchase in bMSContext.Purchase
                          join party in bMSContext.Party on purchase.VendorId equals party.Id
                          where (dateFromParsed == null || purchase.UpdatedAt >= dateFromParsed.Value.Date)
                                && (dateToParsed == null || purchase.UpdatedAt <= dateToParsed.Value.Date)
                                && (postedDateParsed == null || purchase.PostedDate == postedDateParsed.Value.Date)
                                && (partyId == 0 || purchase.VendorId == partyId)
                                && (invNo == "0" || purchase.InvoiceNo == invNo)
                          select new
                          {
                              purchaseId = purchase.Id,
                              vendorId = party.PartyName,
                              invoiceNo = purchase.InvoiceNo,
                              remarks = purchase.Remarks,
                              netCostTotal = purchase.NetCostTotal,
                              netSaleTotal = purchase.NetSaleTotal,
                              netQuantity = purchase.NetQuantity,
                              totalDiscount = purchase.TotalDisc,
                              netProfitInValue = purchase.NetProfitInValue,
                              salePrice = purchase.SalePrice,
                              itemsQuantity = purchase.ItemsQuantity,
                              totalGst = purchase.TotalGst,
                              billTotal = purchase.BillTotal,
                              createdBy = purchase.CreatedBy,
                              createdAt = purchase.CreatedAt,
                              updatedAt = purchase.UpdatedAt,
                              postedDate = purchase.PostedDate,
                              postedBy = purchase.PostedBy,
                              postUnPostStatus = purchase.PostUnpostStatus
                          }).ToList();

            return result;
        }

        [HttpGet]
        [Route("/api/getPurchaseById")]
        public IEnumerable<dynamic> getPurchaseById(int id)
        {
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
                    billTotal = p.BillTotal,
                    netQuantity = p.NetQuantity,
                    totalSalePrice=p.TotalSalePrice

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
                    ItemName = pDtl.ItemName,
                    quantity = pDtl.Quantity,
                    bonusQuantity = pDtl.BonusQuantity,
                    purchasePrice = pDtl.PurchasePrice,
                    discountByPercent = pDtl.DiscountByPercent,
                    discountByValue = pDtl.DiscountByValue,
                    total = pDtl.Total,
                    gstByPercent = pDtl.GstByPercent,
                    gstByValue = pDtl.GstByValue,
                    totalWithGst = pDtl.TotalWithGst,
                    totalIncDisc = pDtl.TotalIncDisc,
                    totalIncGst = pDtl.TotalIncGst,
                    netRate = pDtl.NetRate,
                    netQuantity = pDtl.NetQuantity,
                    subTotal = pDtl.SubTotal,
                    marginPercent = pDtl.MarginPercent,
                    salePrice = pDtl.SalePrice,
                    saleDiscountByValue = pDtl.SaleDiscountByValue,
                    totalSalePrice = pDtl.TotalSalePrice,
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
            //var result = (from po in bMSContext.PurchaseOrder
            //              join p in bMSContext.Party on po.PartyId equals p.Id
            //              select new
            //              {
            //                  partyId = p.PartyName,
            //                  dateOfInvoice = po.DateOfInvoice,
            //                  remarks = po.Remarks,
            //                  createdAt = po.CreatedAt,
            //                  id = po.Id,
            //                  invTotal = po.InvTotal,
            //                  disc = po.Disc,
            //                  endDate = po.EndDate,
            //                  startDate = po.StartDate,
            //                  zeroQty = po.ZeroQty,
            //                  purOrderTerm = po.PurOrderTerm,
            //                  location=po.LocationId,
            //                  postedDate=po.PostedDate,
            //                  status=po.Status,
            //              }).ToList();
            var result = (from po in bMSContext.PurchaseOrder
                          select new
                          {
                              po.Id,
                              po.DateOfInvoice,
                              po.Remarks,
                              po.CreatedAt,
                              po.InvTotal,
                              po.Disc,
                              po.EndDate,
                              po.StartDate,
                              po.ZeroQty,
                              po.PurOrderTerm,
                              po.LocationId,
                              po.PostedDate,
                              po.Status,
                              po.PartyId,
                              po.PartyType,

                              PartyName =
                                  po.PartyType == "Party" ? bMSContext.Party.FirstOrDefault(p => p.Id == po.PartyId).PartyName :
                                  po.PartyType == "Manufacture" ? bMSContext.ItemManufacturer.FirstOrDefault(m => m.Id == po.PartyId).Name :
                                  po.PartyType == "Brand" ? bMSContext.ItemBrand.FirstOrDefault(b => b.Id == po.PartyId).Name :
                                  po.PartyType == "Category" ? bMSContext.ItemCategory.FirstOrDefault(m => m.Id == po.PartyId).Name :
                                  po.PartyType == "Class" ? bMSContext.ItemClass.FirstOrDefault(b => b.Id == po.PartyId).Name :
                                  null
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
                    pOrder.PartyType = purchOrderModel.PartyType;
                    pOrder.Remarks = purchOrderModel.Remarks;
                    pOrder.Disc = purchOrderModel.Disc;
                    pOrder.ProjectionDays = purchOrderModel.ProjectionDays;
                    pOrder.DateOfInvoice = purchOrderModel.DateOfInvoice.ToString();
                    pOrder.EndDate = purchOrderModel.EndDate.ToString();
                    pOrder.StartDate = purchOrderModel.StartDate.ToString();
                    pOrder.InvTotal = purchOrderModel.InvTotal;
                    pOrder.LocationId = purchOrderModel.Location;
                    pOrder.CreatedAt = DateTime.Now.Date.ToString();
                    pOrder.CreatedBy = purchOrderModel.Createdby;
                    pOrder.Status = "UnPost";
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
                            purchOrderDtl.ItemName = purchOrderModel.purcOrderDtlModel[i].ItemName;
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
                    if (data != null)
                    {
                        data[0].PartyId = purchOrderModel.PartyId;
                        data[0].PartyType = purchOrderModel.PartyType;
                        data[0].Remarks = purchOrderModel.Remarks;
                        data[0].Disc = purchOrderModel.Disc;
                        data[0].ProjectionDays = purchOrderModel.ProjectionDays;
                        data[0].DateOfInvoice = purchOrderModel.DateOfInvoice.ToString();
                        data[0].EndDate = purchOrderModel.EndDate.ToString();
                        data[0].StartDate = purchOrderModel.StartDate.ToString();
                        data[0].InvTotal = purchOrderModel.InvTotal;
                        data[0].LocationId = purchOrderModel.Location;
                        data[0].UpdatedAt = DateTime.Now;
                        data[0].UpdatedBy = purchOrderModel.Updatedby;
                        data[0].Status = "UnPost";
                        bMSContext.PurchaseOrder.Update(data[0]);
                        bMSContext.SaveChanges();
                        var dataPurDtl = bMSContext.PurchaseOrderDetail.Where(x => x.OrderId == purchOrderModel.Id).ToList();
                        bMSContext.PurchaseOrderDetail.RemoveRange(dataPurDtl);
                        bMSContext.SaveChanges();
                        if (dataPurDtl != null)
                        {
                            for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                            {
                                PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail();
                                purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = data[0].Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.ItemName = purchOrderModel.purcOrderDtlModel[i].ItemName;
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
                        else
                        {
                            for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                            {
                                PurchaseOrderDetail purchOrderDtl = new PurchaseOrderDetail();
                                purchOrderDtl.RtnQty = purchOrderModel.purcOrderDtlModel[i].RtnQty;
                                purchOrderDtl.SoldQty = purchOrderModel.purcOrderDtlModel[i].SoldQty;
                                purchOrderDtl.OrderId = data[0].Id;
                                purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                                purchOrderDtl.ItemName = purchOrderModel.purcOrderDtlModel[i].ItemName;
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
                  createdAt = po.CreatedAt,
                  location = po.LocationId,
              }).Where(x => x.id == id).ToList();
            var purchaseOrderDetails = bMSContext.PurchaseOrderDetail
                .Select(poDtl => new
                {
                    id = poDtl.Id,
                    orderId = poDtl.OrderId,
                    barCode = poDtl.BarCode,
                    itemId = poDtl.ItemId,
                    itemName = poDtl.ItemName,
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
        [Route("/api/GetPurchaseOrdersByDateRange")]
        public IEnumerable<dynamic> GetPurchaseOrdersByDateRange(string startDate, string endDate, string zeroQty)
        {

            //var conStartdate = Convert.ToDateTime(startDate);
            //var conEnddate = Convert.ToDateTime(endDate);
            var conStartdate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var conEnddate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                                      .AddDays(1)
                                      .AddTicks(-1);
            if (zeroQty == null || zeroQty == "yes")
            {
                var purchaseOrderDetails = bMSContext.PurchaseOrderDetail
                .Where(poDtl => poDtl.CreatedAt >= conStartdate && poDtl.CreatedAt <= conEnddate)
                .Select(poDtl => new
                {
                    id = poDtl.Id,
                    orderId = poDtl.OrderId,
                    barCode = poDtl.BarCode,
                    itemId = poDtl.ItemId,
                    itemName = poDtl.ItemName,
                    soldQty = poDtl.SoldQty,
                    rtnQty = poDtl.RtnQty,
                    netSaleQty = poDtl.NetSaleQty,
                    currentStock = poDtl.CurrentStock,
                    requiredQty = poDtl.RequiredQty,
                    rate = poDtl.Rate,
                    total = poDtl.Total
                }).ToList();
                var result = new
                {
                    //purchaseOrders = purchaseOrders,
                    purchaseOrderDetails = purchaseOrderDetails
                };

                yield return JsonConvert.SerializeObject(result);
            }
            else if (zeroQty == "no")
            {
                var purchaseOrderDetails = bMSContext.PurchaseOrderDetail
                .Where(poDtl => poDtl.CreatedAt >= conStartdate && poDtl.CreatedAt <= conEnddate && poDtl.NetSaleQty != 0 && poDtl.NetSaleQty != null)
                .Select(poDtl => new
                {
                    id = poDtl.Id,
                    orderId = poDtl.OrderId,
                    barCode = poDtl.BarCode,
                    itemId = poDtl.ItemId,
                    itemName = poDtl.ItemName,
                    soldQty = poDtl.SoldQty,
                    rtnQty = poDtl.RtnQty,
                    netSaleQty = poDtl.NetSaleQty,
                    currentStock = poDtl.CurrentStock,
                    requiredQty = poDtl.RequiredQty,
                    rate = poDtl.Rate,
                    total = poDtl.Total
                }).ToList();
                var result = new
                {
                    //purchaseOrders = purchaseOrders,
                    purchaseOrderDetails = purchaseOrderDetails
                };

                yield return JsonConvert.SerializeObject(result);
            }


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
                              disc = po.Disc,
                              flatDisc = po.FlatDisc,
                              itemType = po.ItemType,
                              postedDate=po.PostedDate,
                              postedBy=po.PostedBy,
                              remarks=po.Remarks,
                              PostUnpostStatus = po.PostUnpostStatus
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
                    pOrder.Remarks = purchOrderModel.Remarks;
                    bMSContext.PurchaseReturn.Add(pOrder);
                    bMSContext.SaveChanges();
                    if (purchOrderModel.purcOrderDtlModel.Count() > 0)
                    {
                        for (int i = 0; i <= purchOrderModel.purcOrderDtlModel.Count(); i++)
                        {
                            PurchaseReturnDetail purchOrderDtl = new PurchaseReturnDetail();
                            purchOrderDtl.Barcode = purchOrderModel.purcOrderDtlModel[i].Barcode;
                            purchOrderDtl.OrderReturnId = pOrder.Id;
                            purchOrderDtl.ItemId = purchOrderModel.purcOrderDtlModel[i].ItemId;
                            purchOrderDtl.ItemName = purchOrderModel.purcOrderDtlModel[i].ItemName;
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
                        data.Remarks = purchOrderModel.Remarks;
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
                                    purchOrderDtl.ItemName = purchOrderModel.purcOrderDtlModel[i].ItemName;
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
               remarks = po.Remarks,
               userId = po.UserId,
           }).Where(x => x.id == id).ToList();
            var purchaseOrderDetails = bMSContext.PurchaseReturnDetail
                .Select(poDtl => new
                {
                    id = poDtl.Id,
                    orderReturnId = poDtl.OrderReturnId,
                    barcode = poDtl.Barcode,
                    itemId = poDtl.ItemId,
                    itemName = poDtl,
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
