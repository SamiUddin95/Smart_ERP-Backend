using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class RentController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllRents")]
        public IEnumerable<Rent> getAllRents()
        {
            return bMSContext.Rent.ToList();
        }
        [HttpPost]
        [Route("/api/createRent")]
        public object createRent(Rent rent)
        {

            try
            {
                try
                {
                    var rntCheck = bMSContext.Rent.SingleOrDefault(u => u.RentId == rent.RentId);
                    if (rntCheck != null)
                    {
                        rntCheck.RentId= rent.RentId;
                        rntCheck.ShopId= rent.ShopId;
                        rntCheck.MonthId = rent.MonthId;
                        rntCheck.ElectricityBill= rent.ElectricityBill;
                        rntCheck.AgreementTypeId= rent.AgreementTypeId;
                        rntCheck.Maintenance= rent.Maintenance;
                        rntCheck.Year= rent.Year;
                        rntCheck.Date = rent.Date;
                        //rntCheck.MonthRent = rent.MonthRent;
                        //rntCheck.MonthBalance = rent.MonthBalance;
                        //rntCheck.RentReceived = rent.RentReceived;
                        bMSContext.Rent.Update(rntCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = rntCheck.RentId });
                    }
                    else
                    {
                        Rent rnt= new Rent();
                        rnt.RentId = rent.RentId;
                        rnt.ShopId = rent.ShopId;
                        rnt.MonthId = rent.MonthId;
                        rnt.ElectricityBill = rent.ElectricityBill;
                        rnt.AgreementTypeId = rent.AgreementTypeId;
                        rnt.Maintenance = rent.Maintenance;
                        rnt.Year = rent.Year;
                        rnt.Date = rent.Date;
                        //rnt.MonthRent = rent.MonthRent;
                        //rnt.MonthBalance = rent.MonthBalance;
                        //rnt.RentReceived = rent.RentReceived;
                        bMSContext.Rent.Add(rnt);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = rnt.RentId});
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
        [Route("/api/deleteRentById")]
        public object deleteRentById(long id)
        {
            try
            {
                var rnt = bMSContext.Rent.SingleOrDefault(u => u.RentId == id);
                if (rnt != null)
                {
                    bMSContext.Rent.Remove(rnt);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = rnt.RentId});
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getRentById")]
        public IEnumerable<Rent> getRentById(long id)
        {
            return bMSContext.Rent.Where(u => u.RentId == id).ToList();
        }
    }
}
