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
    public class SaleController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllCounterSales")]
        public IEnumerable<Sale> getAllCounterSales()
        {
            return bMSContext.Sale.ToList();
        }

        [HttpPost]
        [Route("/api/createCounterSale")]
        public object createCounterSale(CounterSaleModel couSale)
        {

            try
            {
                try
                {
                    var couSalechk = bMSContext.Sale.SingleOrDefault(u => u.Id == couSale.Id);
                    if (couSalechk != null)
                    {

                        couSalechk.Id = couSale.Id;
                        couSalechk.GrossSale = couSale.GrossSale;
                        couSalechk.NetSaleTotal = couSale.NetSaleTotal;
                        couSalechk.Return = couSale.Return;
                        couSalechk.EarnedPoints = couSale.EarnedPoints;
                        couSalechk.DiscountPerc = couSale.DiscountPerc;
                        couSalechk.DiscountValue = couSale.DiscountValue;
                        couSalechk.FlatDisc = couSale.FlatDisc;
                        couSalechk.GrandTotal = couSale.GrandTotal;
                        couSalechk.EarnedPoints = couSale.EarnedPoints;
                        couSalechk.CashBack = couSale.CashBack;
                        couSalechk.CashCharged = couSale.CashCharged;
                        couSalechk.CashReceived = couSale.CashReceived;
                        couSalechk.UpdatedAt = DateTime.Now;
                        couSalechk.UpdatedBy = couSale.Updatedby;
                        bMSContext.Sale.Update(couSalechk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = couSalechk.Id });
                    }
                    else
                    {
                        DateTime dateOnly = DateTime.Now.Date;
                        string dateString = dateOnly.ToString("yyyy-MM-dd");
                        var saleTill = bMSContext.SaleTill.SingleOrDefault(x => x.TillOpenDateTime == dateString);
                        if (saleTill == null)
                        {
                            return JsonConvert.SerializeObject(new { id = 0 });
                        }
                        Sale counterSale = new Sale();
                        counterSale.Id = couSale.Id;
                        counterSale.GrossSale = couSale.GrossSale;
                        counterSale.GrossSale = couSale.GrossSale;
                        counterSale.NetSaleTotal = couSale.NetSaleTotal;
                        counterSale.Return = couSale.Return;
                        counterSale.EarnedPoints = couSale.EarnedPoints;
                        counterSale.DiscountPerc = couSale.DiscountPerc;
                        counterSale.DiscountValue = couSale.DiscountValue;
                        counterSale.FlatDisc = couSale.FlatDisc;
                        counterSale.GrandTotal = couSale.GrandTotal;
                        counterSale.CashBack = couSale.CashBack;
                        counterSale.CashCharged = couSale.CashCharged;
                        counterSale.CashReceived = couSale.CashReceived;
                        counterSale.InvoiceType = couSale.InvoiceType;
                        counterSale.InvoiceBalance = couSale.InvoiceBalance;
                        counterSale.CreatedAt = DateTime.Now;
                        counterSale.CreatedBy = couSale.Createdby;
                        bMSContext.Sale.Add(counterSale);
                        PaymentDetail paymentDetail = new PaymentDetail();
                        if (couSale.InvoiceType == "Cash")
                            paymentDetail.CashBack = couSale.CashBack;
                        if (couSale.InvoiceType == "Credit")
                            paymentDetail.CashBack = 0;
                        if (couSale.InvoiceType == "Cash")
                            paymentDetail.CashCharged = couSale.CashCharged;
                        if (couSale.InvoiceType == "Credit")
                            paymentDetail.CashCharged= 0; 
                        paymentDetail.SaleId= couSale.Id;
                        paymentDetail.NetTotal = couSale.NetAmount;
                        if (couSale.InvoiceType == "Cash")
                            paymentDetail.CashReceived = couSale.CashCharged;
                        if (couSale.InvoiceType == "Credit")
                            paymentDetail.CashReceived = 0; 
                        if (couSale.InvoiceType == "Cash")
                        {
                            paymentDetail.ExtraCharges = 0;
                            paymentDetail.ExtraChargesPer = 0;
                        }
                        if (couSale.InvoiceType == "Credit")
                        {
                            paymentDetail.ExtraCharges = couSale.ExtraCharges;
                            paymentDetail.ExtraChargesPer = couSale.ExtraChargesPer;
                        }
                        paymentDetail.InvType = couSale.InvoiceType;
                        paymentDetail.FinalAmount = couSale.FinalAmount;
                        paymentDetail.RemainingCreditAmount = couSale.remainingCreditAmount;
                        paymentDetail.SaleId = counterSale.Id;
                        bMSContext.PaymentDetail.Add(paymentDetail);
                        saleTill.TillCloseAmount = saleTill.TillCloseAmount + couSale.CashCharged;
                        saleTill.NetSale = saleTill.NetSale + couSale.GrandTotal;
                        saleTill.NetSale = saleTill.NetSale + couSale.GrandTotal;
                        saleTill.NetSale = saleTill.NetSale + couSale.GrandTotal;
                        saleTill.NetSale = saleTill.NetSale + couSale.GrandTotal;
                        if (couSale.InvoiceType == "Cash")
                            saleTill.CashSale = saleTill.CashSale + couSale.CashCharged;
                        if (couSale.InvoiceType == "Credit")
                            saleTill.CreditSale = saleTill.CreditSale + couSale.CashCharged;
                        bMSContext.SaleTill.Update(saleTill);
                        bMSContext.SaveChanges();
                        foreach(var item in couSale.counterSaleDetails) 
                        {
                            SaleDetail sdl = new SaleDetail();
                            sdl.SaleId = counterSale.Id;
                            sdl.Qty = item.Qty;
                            sdl.Discount = item.Discount;
                            sdl.ItemName = item.ItemName;
                            sdl.BarCode = item.BarCode;
                            sdl.SalePrice = item.SalePrice;
                            sdl.NetSalePrice = item.NetSalePrice;
                            bMSContext.SaleDetail.Add(sdl);
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
        [Route("/api/getAllSaleReturn")]
        public IEnumerable<SaleReturn> getAllSaleReturn()
        {
            return bMSContext.SaleReturn.ToList();
        }

        [HttpPost]
        [Route("/api/createSaleReturn")]
        public object createSaleReturn(SaleReturnModel couSale)
        {

            try
            {
                try
                {
                    var couSalechk = bMSContext.SaleReturn.SingleOrDefault(u => u.Id == couSale.Id);
                    if (couSalechk != null)
                    {

                        couSalechk.Id = couSale.Id;
                        couSalechk.DiscByValue = couSale.DiscByValue;
                        couSalechk.NetSaleReturnTotal = couSale.NetSaleReturnTotal;
                        couSalechk.DiscByPercent = couSale.DiscByPercent;
                        couSalechk.GrandTotal = couSale.GrandTotal;
                        couSalechk.Deduction = couSale.Deduction;
                        couSalechk.GrossSaleReturn = couSale.GrossSaleReturn;
                        couSalechk.GrandTotal = couSale.GrandTotal;
                        couSalechk.UpdatedAt = DateTime.Now;
                        couSalechk.UpdatedBy = couSale.Updatedby;
                        couSalechk.UserId = couSale.UserId;
                        bMSContext.SaleReturn.Update(couSalechk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = couSalechk.Id });
                    }
                    else
                    {
                        SaleReturn counterSale = new SaleReturn();
                        counterSale.DiscByValue = couSale.DiscByValue;
                        counterSale.NetSaleReturnTotal = couSale.NetSaleReturnTotal;
                        counterSale.DiscByPercent = couSale.DiscByPercent;
                        counterSale.GrandTotal = couSale.GrandTotal;
                        counterSale.GrossSaleReturn = couSale.GrossSaleReturn;
                        counterSale.Deduction = couSale.Deduction;
                        counterSale.CreatedAt = DateTime.Now;
                        counterSale.CreatedBy = couSale.Createdby;
                        counterSale.UserId = couSale.UserId;
                        bMSContext.SaleReturn.Add(counterSale);
                        bMSContext.SaveChanges();
                        foreach (var item in couSale.saleReturnDetails)
                        {
                            SaleReturnDetail sdl = new SaleReturnDetail();
                            sdl.SaleReturnId = counterSale.Id;
                            sdl.ItemName = item.ItemName;
                            sdl.Barcode = item.BarCode;
                            sdl.Discount = item.Discount;
                            sdl.Qty = item.Qty;
                            sdl.NetSalePrice = item.NetSalePrice;
                            bMSContext.SaleReturnDetail.Add(sdl);
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
        [Route("/api/deleteCounterSaleById")]
        public object deleteBrandById(int id)
        {
            try
            {
                var delbrand = bMSContext.ItemBrand.SingleOrDefault(u => u.Id == id);
                if (delbrand != null)
                {
                    bMSContext.ItemBrand.Remove(delbrand);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delbrand.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpPost]
        [Route("/api/createCashIn")]
        public object createCashIn(SaleCash saleCash)
        {
            try
            {
                var data = bMSContext.SaleCash.SingleOrDefault(x => x.Id == saleCash.Id);
                if (data != null)
                {
                    data.CashInAmount = saleCash.CashInAmount;
                    data.TillOpenNo = saleCash.TillOpenNo;
                    data.Notes = saleCash.Notes;
                    data.UserId = saleCash.UserId;
                    data.CashInDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    bMSContext.SaleCash.Update(data);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = data.Id });
                }
                else
                {
                    DateTime dateOnly = DateTime.Now.Date;
                    string dateString = dateOnly.ToString("yyyy-MM-dd");
                    var dataToChk = bMSContext.SaleCash.SingleOrDefault(x => x.CashInDateTime == dateString);
                    if (dataToChk != null)
                    {
                        return JsonConvert.SerializeObject(new { id = 0 });

                    }
                    SaleCash sleCsh = new SaleCash();
                    sleCsh.CashInAmount = saleCash.CashInAmount;
                    sleCsh.TillOpenNo = saleCash.TillOpenNo;
                    sleCsh.Notes = saleCash.Notes;
                    sleCsh.UserId = saleCash.UserId;
                    sleCsh.CashInDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    bMSContext.SaleCash.Add(sleCsh);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = sleCsh.Id });
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpGet]
        [Route("/api/getAllCashIn")]
        public IEnumerable<SaleCash> getAllCashIn()
        {
            return bMSContext.SaleCash.ToList();
        }
        [HttpGet]
        [Route("/api/getCheckCashIn")]
        public object getCheckCashIn()
        {
            DateTime dateOnly = DateTime.Now.Date;
            string dateString = dateOnly.ToString("yyyy-MM-dd");
            var saleTill = bMSContext.SaleCash.SingleOrDefault(x => x.CashInDateTime == dateString);
            if (saleTill == null)
            {
                return JsonConvert.SerializeObject(new { msg = "please cash in first!" });
            }
            else
                return JsonConvert.SerializeObject(new { msg = "Cash is in!" });
        }
        [HttpPost]
        [Route("/api/createSaleTIllOpen")]
        public object createSaleTIllOpen(SaleTill saleTill)
        {
            try
            {
                var data = bMSContext.SaleTill.SingleOrDefault(x => x.Id == saleTill.Id);
                if (data != null)
                {
                    data.TillOpenAmount = saleTill.TillOpenAmount;
                    data.TillCloseAmount = 0;
                    data.CashSale = 0;
                    data.CreditSale = 0;
                    data.NetSale = 0;
                    data.TillNo = saleTill.TillNo;
                    data.Notes = saleTill.Notes;
                    data.TillOpenDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    data.TillCloseDateTime = saleTill.TillCloseDateTime;
                    data.SaleTillId = 1;
                    bMSContext.SaleTill.Update(data);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = data.Id });
                }
                else
                {
                    DateTime dateOnly = DateTime.Now.Date;
                    string dateString = dateOnly.ToString("yyyy-MM-dd");
                    var dataToChk = bMSContext.SaleTill.SingleOrDefault(x => x.TillOpenDateTime == dateString);
                    if (dataToChk != null)
                    {
                        return JsonConvert.SerializeObject(new { id = 0 });

                    }
                    SaleTill till = new SaleTill();
                    till.TillOpenAmount = saleTill.TillOpenAmount;
                    till.TillNo = saleTill.TillNo;
                    till.Notes = saleTill.Notes;
                    till.TillCloseAmount = 0;
                    till.CashSale = 0;
                    till.CreditSale = 0;
                    till.NetSale = 0;
                    till.TillOpenDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    till.SaleTillId = 1;
                    bMSContext.SaleTill.Add(till);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = till.Id });
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpGet]
        [Route("/api/getAllTillOpen")]
        public IEnumerable<SaleTill> getAllTillOpen()
        {
            return bMSContext.SaleTill.ToList();
        }
        [HttpGet]
        [Route("/api/getCheckTillOpen")]
        public object getCheckTillOpen()
        {
            DateTime dateOnly = DateTime.Now.Date;
            string dateString = dateOnly.ToString("yyyy-MM-dd");
            var saleTill = bMSContext.SaleTill.SingleOrDefault(x => x.TillOpenDateTime == dateString);
            if (saleTill == null)
            {
                return JsonConvert.SerializeObject(new { msg = "please till open first!" });
            }
            else
                return JsonConvert.SerializeObject(new { msg = "Till is open!" });
        }

        [HttpGet]
        [Route("/api/getSaleById")]
        public IEnumerable<ItemBrand> getSaleById(int id)
        {
            return bMSContext.ItemBrand.Where(u => u.Id == id).ToList();
        }




        [HttpGet]
        [Route("/api/getTillOpenById")]
        public IEnumerable<SaleTill> getTillOpenById(int id)
        {
            return bMSContext.SaleTill.Where(u => u.Id == id).ToList();
        }

        [HttpPost]
        [Route("/api/createSaleTIllClose")]
        public object createSaleTIllClose(SaleTill saleTill)
        {
            try
            {
                var data = bMSContext.SaleTill.SingleOrDefault(x => x.Id == saleTill.Id);
                if (data != null)
                {
                    data.TillCloseAmount = saleTill.TillCloseAmount;
                    data.Difference = data.NetSale - saleTill.TillCloseAmount;
                    if(data.Difference>0)
                    data.ExcessShort = "Shortage";
                    if (data.Difference < 0)
                        data.ExcessShort = "Excess";
                    data.Notes = saleTill.Notes;
                    data.TillOpenDateTime = data.TillOpenDateTime;
                    data.TillCloseDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    data.SaleTillId = 2;
                    data.UpdatedAt = DateTime.Now;
                    bMSContext.SaleTill.Update(data);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = data.Id });
                }
                else
                {
                    SaleTill till = new SaleTill();
                    till.TillCloseAmount = saleTill.TillCloseAmount;
                    till.Notes = saleTill.Notes;
                    till.TillOpenDateTime = DateTime.Now.ToString("yyyy-MM-dd :hh mm");
                    till.TillCloseDateTime = saleTill.TillCloseDateTime;
                    till.SaleTillId = 2;
                    data.CreatedAt = DateTime.Now;
                    data.UpdatedAt = DateTime.Now;
                    bMSContext.SaleTill.Add(till);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = till.Id });
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpGet]
        [Route("/api/getAllTillClose")]
        public IEnumerable<SaleTill> getAllTillClose()
        {
            return bMSContext.SaleTill.ToList();
        }

        [HttpPost]
        [Route("/api/createCashOut")]
        public object createCashOut(SaleCash cashOut)
        {
            try
            {
                var data = bMSContext.SaleCash.SingleOrDefault(x => x.Id == cashOut.Id);
                if (data != null)
                {
                    data.CashOutAmount = cashOut.CashOutAmount;   
                    data.CashOutDateTime = DateTime.Now.ToString("yyyy-MM-dd"); 
                    bMSContext.SaleCash.Update(data);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = data.Id });
                }
                else
                {
                    SaleCash sleCsh = new SaleCash();
                    sleCsh.CashOutAmount = cashOut.CashOutAmount;
                    sleCsh.CashOutDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    bMSContext.SaleCash.Add(sleCsh);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = sleCsh.Id });
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpGet]
        [Route("/api/getAllCashOut")]
        public IEnumerable<SaleCash> getAllCashOut()
        {
            return bMSContext.SaleCash.ToList();
        }
    }
}
