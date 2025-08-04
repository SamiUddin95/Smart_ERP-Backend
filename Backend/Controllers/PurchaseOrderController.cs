using Backend.Model;
using Backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly FileLogger _logger;
        private readonly IConfiguration _configuration;
        public PurchaseOrderController(FileLogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
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
                    OpenPurchk.UpdatedAt = DateTime.Now;
                    OpenPurchk.UpdatedBy = openingPurchase.UpdatedBy;
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
                    purchaseOpeningPurchase.CreatedAt = DateTime.Now;
                    purchaseOpeningPurchase.CreatedBy = openingPurchase.CreatedBy;
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


        [HttpGet]
        [Route("/api/SupplierWise")]
        public IActionResult SupplierWise(string tableName)
        {

            switch (tableName)
            {
                case "Brand":
                    var brands = bMSContext.ItemBrand
                        .Select(b => new { b.Id, b.Name })
                        .ToList();
                    return Ok(brands);

                case "Party":
                    var parties = bMSContext.Party
                        .Select(p => new { p.Id, p.PartyName })
                        .ToList();
                    return Ok(parties);

                case "Manufacture":
                    var manufacture = bMSContext.ItemManufacturer
                        .Select(b => new { b.Id, b.Name })
                        .ToList();
                    return Ok(manufacture);

                case "Class":
                    var itemClass = bMSContext.ItemClass
                        .Select(p => new { p.Id, p.Name })
                        .ToList();
                    return Ok(itemClass);

                case "Category":
                    var category = bMSContext.ItemCategory
                        .Select(p => new { p.Id, p.Name })
                        .ToList();
                    return Ok(category);

                default:
                    return null;
            }
        }
        [HttpGet]
        [Route("/api/getLocation")]
        public IEnumerable<Location> getLocation()
        {
            return bMSContext.Location.ToList();
        }

        [HttpGet]
        [Route("/api/postPurchaseOrder")]
        public object postPurchase(int purchaseId, string postedBy, string barCodes, string currentStock, string lastNetSalePrice,
    string lastNetCost, string saleDisc, string netSaleePrice)
        {
            try
            {
                //string[] barCodeArray = barCodes.Split(',');
                //string[] currentStockArray = currentStock.Split(',');
                //string[] lastNetSalePriceArray = lastNetSalePrice.Split(',');
                //string[] lastNetCostArray = lastNetCost.Split(',');
                //string[] saleDiscArray = saleDisc.Split(',');
                //string[] netSalePriceArray = netSaleePrice.Split(',');
                //int length = new int[] { barCodeArray.Length,
                //    currentStockArray.Length,lastNetSalePriceArray.Length,lastNetCostArray.Length,
                //    saleDiscArray.Length, netSalePriceArray.Length
                //    }.Min();
                var postedDate = bMSContext.PurchaseOrder.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = postedBy;
                    postedDate.Status = "Posted";
                    postedDate.DeliveryStatus = "Received";
                    bMSContext.PurchaseOrder.Update(postedDate);
                    bMSContext.SaveChanges();
                }
                //for (int i = 0; i < length; i++)
                //{
                //    var barcode = barCodeArray[i];
                //    var stock = (int)Math.Floor(double.Parse(currentStockArray[i]));
                //    var salePrice = (int)Math.Floor(double.Parse(lastNetSalePriceArray[i]));
                //    var cost = (int)Math.Floor(double.Parse(lastNetCostArray[i]));
                //    var disc = (int)Math.Floor(double.Parse(saleDiscArray[i]));
                //    var netSalePrice = (int)Math.Floor(double.Parse(netSalePriceArray[i]));


                //    var itemDtl = bMSContext.Item.Where(x => x.AliasName == barcode).FirstOrDefault();
                //    if (itemDtl != null)
                //    {
                //        itemDtl.CurrentStock = Convert.ToInt16(stock);
                //        itemDtl.PurchasePrice = Convert.ToInt16(cost);
                //        itemDtl.SalePrice = Convert.ToInt16(salePrice);
                //        itemDtl.Discflat = Convert.ToInt16(saleDisc);
                //        itemDtl.NetSalePrice = Convert.ToInt16(netSalePrice);
                //        bMSContext.Item.Update(itemDtl);
                //        bMSContext.SaveChanges();

                //    }
                //}
            }
            catch (Exception ex)
            { }
            return JsonConvert.SerializeObject(new { status = "OK", msg = "Items Posted successfully" });
        }

        [HttpGet]
        [Route("/api/unPostPurchaseOrder")]
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
                var postedDate = bMSContext.PurchaseOrder.Where(x => x.Id == purchaseId).FirstOrDefault();
                if (postedDate != null)
                {
                    postedDate.PostedDate = DateTime.Now.Date;
                    postedDate.PostedBy = null;
                    postedDate.Status = "UnPost";
                    postedDate.DeliveryStatus = "Pending";
                    bMSContext.PurchaseOrder.Update(postedDate);
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
        [Route("/api/getAllPurchaseOrderDashboard")]
        public IEnumerable<dynamic> getAllPurchaseOrderDashboard()
        {
            var statuses = new[] { "Send", "Delivered" };
            var purchaseOrderDashBoard = (
                from po in bMSContext.PurchaseOrder
                join p in bMSContext.Party on po.PartyId equals p.Id
                join l in bMSContext.Location on po.LocationId equals l.Id
                where statuses.Contains(po.DeliveryStatus)
                select new
                {
                    Id = po.Id,
                    Location = l.Name,
                    DeliveryDate = po.DeliveryDate,
                    Party = p.PartyName,
                    InvoiceTotal = po.InvTotal,
                    DeliveryStatus = po.DeliveryStatus
                }
            )
            .ToList()
            .OrderByDescending(x => x.DeliveryDate);


            return purchaseOrderDashBoard;

        }



        [HttpGet]
        [Route("/api/changeDeliveryStatus")]
        public IEnumerable<dynamic> changeDeliveryStatus(string ids)
        {
            try
            {
                string[] idsArray = ids.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var idList = idsArray.Select(id => Convert.ToInt64(id)).ToList();
                var receivedData = bMSContext.PurchaseOrder.Where(x => idList.Contains(x.Id)).ToList();
                foreach (var order in receivedData)
                {
                    order.DeliveryStatus = "Send";
                }
                bMSContext.SaveChanges();
                return idsArray;
            }

            catch(Exception ex)
            {
                _logger.LogError(MethodBase.GetCurrentMethod()?.Name, ex);
                return null;
            }
        }

        [HttpGet]
        [Route("/api/GetPurchaseOrdersByDateRange")]
        public IEnumerable<dynamic> GetPurchaseOrdersByDateRange(string startDate, string endDate, string zeroQty, string selectedTable, string partyId)
        {
            var conStartdate = DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var conEnddate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var resultList = new List<dynamic>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetPurchaseOrdersByDateRange", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StartDate", conStartdate);
                    cmd.Parameters.AddWithValue("@EndDate", conEnddate);
                    cmd.Parameters.AddWithValue("@ZeroQty", string.IsNullOrEmpty(zeroQty) ? "yes" : zeroQty);
                    cmd.Parameters.AddWithValue("@selectedTable", selectedTable);
                    cmd.Parameters.AddWithValue("@partyId", partyId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultList.Add(new
                            {
                                barCode = reader["Barcode"]?.ToString(),
                                itemName = reader["ITEM_NAME"]?.ToString(),
                                requiredQty = reader["Required_Qty"] != DBNull.Value ? Convert.ToDecimal(reader["Required_Qty"]) : 0,
                                currentStock = reader["CURRENT_STOCK"] != DBNull.Value ? Convert.ToDecimal(reader["CURRENT_STOCK"]) : 0,
                                createdAt = reader["CREATED_AT"] != DBNull.Value ? Convert.ToDateTime(reader["CREATED_AT"]) : (DateTime?)null,
                                netSaleQty = reader["NetSaleQty"] != DBNull.Value ? Convert.ToDecimal(reader["NetSaleQty"]) : 0,
                                rate = reader["NET_RATE"] != DBNull.Value ? Convert.ToDecimal(reader["NET_RATE"]) : 0,
                                soldQty = reader["SoldQty"] != DBNull.Value ? Convert.ToDecimal(reader["SoldQty"]) : 0,
                                rtnQty = reader["ReturnQty"] != DBNull.Value ? Convert.ToDecimal(reader["ReturnQty"]) : 0,
                                total = reader["total"] != DBNull.Value ? Convert.ToDecimal(reader["total"]) : 0,
                            });
                        }
                    }
                }
            }

            var result = new
            {
                purchaseOrderDetails = resultList
            };

            yield return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        [Route("/api/createPO")]
        public object createPO([FromBody] List<RequiredQtyDTO> qtyDTOs)
        {
            try
            {

                foreach (var item in qtyDTOs)
                {
                    if (item.ItemName != null)
                    {
                        var Itemschk = bMSContext.Item.SingleOrDefault(u => u.ItemName == item.ItemName);
                        Itemschk.RequiredQty = item.RequiredQty;
                        bMSContext.Item.Update(Itemschk);
                        bMSContext.SaveChanges();
                    }
                }
            }

            catch (Exception ex)
            {
                JsonConvert.SerializeObject(new { msg = ex.Message });
            }
            return JsonConvert.SerializeObject(new { msg = "Message" });

        }
    }
}
