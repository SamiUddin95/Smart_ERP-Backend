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
        public IEnumerable<CounterSale> getAllCounterSales()
        {
            return bMSContext.CounterSale.ToList();
        }

        [HttpPost]
        [Route("/api/createCounterSale")]
        public object createCounterSale(CounterSaleModel couSale)
        {

            try
            {
                try
                {
                    var couSalechk = bMSContext.CounterSale.SingleOrDefault(u => u.Id == couSale.Id);
                    if (couSalechk != null)
                    {

                        couSalechk.Id = couSale.Id;
                        couSalechk.GrossSale = couSale.GrossSale;
                        couSalechk.NetAmount = couSale.NetAmount;
                        couSalechk.Return = couSale.Return;
                        couSalechk.EarnedPoints = couSale.EarnedPoints;
                        couSalechk.Misc = couSale.Misc;
                        couSalechk.Discount = couSale.Discount;
                        couSalechk.TotalDiscount = couSale.TotalDiscount;
                        couSalechk.GrandTotal = couSale.GrandTotal;
                        couSalechk.UpdatedAt = DateTime.Now;
                        couSalechk.UpdatedBy = couSale.Updatedby;
                        bMSContext.CounterSale.Update(couSalechk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = couSalechk.Id });
                    }
                    else
                    {
                        CounterSale counterSale = new CounterSale();
                        counterSale.Id = couSale.Id;
                        counterSale.GrossSale = couSale.GrossSale;
                        counterSale.NetAmount = couSale.NetAmount;
                        counterSale.Return = couSale.Return;
                        counterSale.EarnedPoints = couSale.EarnedPoints;
                        counterSale.Misc = couSale.Misc;
                        counterSale.Discount = couSale.Discount;
                        counterSale.TotalDiscount = couSale.TotalDiscount;
                        counterSale.GrandTotal = couSale.GrandTotal;
                        counterSale.FlatDiscount = couSale.FlatDiscount;
                        counterSale.CreatedAt = DateTime.Now;
                        counterSale.CreatedBy = couSale.Createdby;
                        bMSContext.CounterSale.Add(counterSale);
                        bMSContext.SaveChanges();
                        foreach(var item in couSale.counterSaleDetails) 
                        {

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

        [HttpGet]
        [Route("/api/getCounterSaleById")]
        public IEnumerable<ItemBrand> getBrandById(int id)
        {
            return bMSContext.ItemBrand.Where(u => u.Id == id).ToList();
        }
    }
}
