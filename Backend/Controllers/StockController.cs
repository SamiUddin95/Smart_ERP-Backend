using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Backend.Model;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class StockController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllStockAdj")]
        public IEnumerable<StockAdjustment> getAllStockAdj()
        {
            return bMSContext.StockAdjustment.ToList();
        }

        [HttpPost]
        [Route("/api/createStockAdj")]
        public object createStockAdj(StockAjdModel couSale)
        {

            try
            {
                try
                {
                    var couSalechk = bMSContext.StockAdjustment.SingleOrDefault(u => u.Id == couSale.Id);
                    if (couSalechk != null)
                    { 
                        couSalechk.Id = couSale.Id;
                        couSalechk.Remarks = couSale.Remarks;
                        couSalechk.Date = couSale.Date;
                        couSalechk.Status = couSale.Status;
                        couSalechk.DifferQty = couSale.DifferQty;
                        couSalechk.DfferQtyAmount = couSale.DfferQtyAmount;
                        couSalechk.Location = couSale.Location;
                        couSalechk.StockInHand = couSale.StockInHand;
                        couSalechk.StockInHandAmount = couSale.StockInHandAmount;
                        couSalechk.StockInShelf = couSale.StockInShelf;
                        couSalechk.StockInShelfAmount = couSale.StockInShelfAmount;
                        couSalechk.TotalAmountDecrease = couSale.TotalAmountDecrease;
                        couSalechk.TotalAmountIncrease = couSale.TotalAmountIncrease;
                        couSalechk.UserId = couSale.UserId;
                        couSalechk.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd");
                        couSalechk.UpdatedBy = couSale.UpdatedBy;
                        bMSContext.StockAdjustment.Update(couSalechk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = couSalechk.Id });
                    }
                    else
                    { 
                        StockAdjustment counterSale = new StockAdjustment();
                        counterSale.Remarks = couSale.Remarks;
                        counterSale.Date = couSale.Date;
                        counterSale.Status = couSale.Status;
                        counterSale.DifferQty = couSale.DifferQty;
                        counterSale.DfferQtyAmount = couSale.DfferQtyAmount;
                        counterSale.Location = couSale.Location;
                        counterSale.StockInHand = couSale.StockInHand;
                        counterSale.StockInHandAmount = couSale.StockInHandAmount;
                        counterSale.StockInShelf = couSale.StockInShelf;
                        counterSale.StockInShelfAmount = couSale.StockInShelfAmount;
                        counterSale.TotalAmountDecrease = couSale.TotalAmountDecrease;
                        counterSale.TotalAmountIncrease = couSale.TotalAmountIncrease;
                        counterSale.UserId = couSale.UserId;
                        counterSale.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
                        counterSale.CreatedBy = couSale.UpdatedBy;
                        bMSContext.StockAdjustment.Add(counterSale);   
                        bMSContext.SaveChanges();
                        foreach (var item in couSale.stckAdjDtl)
                        {
                            stckAdjDtlModel sdl = new stckAdjDtlModel();
                            sdl.StckAdjId = counterSale.Id;
                            sdl.Total = item.Total;
                            sdl.PurchasePrice = item.PurchasePrice;
                            sdl.ItemName = item.ItemName;
                            sdl.BarCode = item.BarCode;
                            sdl.SalePrice = item.SalePrice;
                            sdl.Batch = item.Batch;
                            sdl.Expiry = item.Expiry;
                            sdl.Location = item.Location;
                            sdl.StockInHand = item.StockInHand;
                            sdl.StockInShelf = item.StockInShelf;
                            bMSContext.StockAdjDetail.Add(item);
                            bMSContext.SaveChanges();

                        }
                        return JsonConvert.SerializeObject(new { id = counterSale.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("/api/getAllJournalVoucher")]
        public IEnumerable<JournalVoucher> getAllJournalVoucher()
        {
            return bMSContext.JournalVoucher.ToList();
        }

        [HttpPost]
        [Route("/api/createJournalVoucher")]
        public object createjournalVoucher(JournalVoucherModel couSale)
        {

            try
            {
                try
                {
                    var couSalechk = bMSContext.JournalVoucher.SingleOrDefault(u => u.Id == couSale.Id);
                    if (couSalechk != null)
                    {
                        couSalechk.Id = couSale.Id;
                        couSalechk.AccountBalance = couSale.AccountBalance;
                        couSalechk.Location = couSale.Location;
                        couSalechk.CreationDate = couSale.CreationDate;
                        couSalechk.Amount = couSale.Amount;
                        couSalechk.Datetime = couSale.Datetime;
                        couSalechk.CreatedBy = couSale.CreatedBy;
                        couSalechk.CreationDate = couSale.CreationDate;
                        couSalechk.PostedBy = couSale.PostedBy;
                        couSalechk.PostingDate = couSale.PostingDate;
                        couSalechk.Description = couSale.Description;
                        couSalechk.ReferenceNo = couSale.ReferenceNo;
                        couSalechk.UserId = couSale.UserId; 
                        bMSContext.JournalVoucher.Update(couSalechk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = couSalechk.Id });
                    }
                    else
                    {
                        JournalVoucher counterSale = new JournalVoucher();
                        counterSale.Id = couSale.Id;
                        counterSale.AccountBalance = couSale.AccountBalance;
                        counterSale.Location = couSale.Location;
                        counterSale.CreationDate = couSale.CreationDate.ToString();
                        counterSale.Amount = couSale.Amount;
                        counterSale.Datetime = couSale.Datetime;
                        counterSale.CreatedBy = couSale.CreatedBy;
                        counterSale.PostingDate = couSale.PostingDate;
                        counterSale.CreationDate = couSale.CreationDate;
                        counterSale.PostedBy = couSale.PostedBy;
                        counterSale.Description = couSale.Description;
                        counterSale.ReferenceNo = couSale.ReferenceNo;
                        counterSale.UserId = couSale.UserId;
                        bMSContext.JournalVoucher.Add(counterSale);
                        bMSContext.SaveChanges();
                        foreach (var item in couSale.jurnlVuchrDtl)
                        {
                            JournalVoucherDetail sdl = new JournalVoucherDetail();
                            sdl.JournalVoucherId = counterSale?.Id;
                            sdl.DebitAccName = item.DebitAccName;
                            sdl.DebitAccCode = item.DebitAccCode;
                            sdl.CreditAccName = item.CreditAccName;
                            sdl.CreditAccCode = item.CreditAccCode;
                            sdl.Amount = item.Amount;
                            sdl.Description = item.Description;
                            sdl.RefNo = item.RefNo;
                            bMSContext.JournalVoucherDetail.Add(sdl);
                            bMSContext.SaveChanges();

                        }
                        return JsonConvert.SerializeObject(new { id = counterSale.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
