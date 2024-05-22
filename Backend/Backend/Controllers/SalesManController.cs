using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class SalesManController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllSalesMan")]
        public IEnumerable<SalesMan> getAllSalesMan()
        {
            return bMSContext.SalesMan.ToList();
        }
        [HttpGet]
        [Route("/api/getAllSalesManType")]
        public IEnumerable<SalesManType> getAllSalesManType()
        {
            return bMSContext.SalesManType.ToList();
        }
        [HttpPost]
        [Route("/api/createSalesMan")]
        public object createSalesMan(SalesMan sm)
        {

            try
            {
                try
                {
                    var smCheck = bMSContext.SalesMan.SingleOrDefault(u => u.Id == sm.Id);
                    if (smCheck != null)
                    {
                        smCheck.Name = sm.Name;
                        smCheck.SalesManTypeId= sm.SalesManTypeId;
                        smCheck.IsActive = sm.IsActive;  
                        bMSContext.SalesMan.Update(smCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = sm.Id });
                    }
                    else
                    {
                        SalesMan smm = new SalesMan();
                        smm.Name = sm.Name;
                        smm.SalesManTypeId = sm.SalesManTypeId;
                        smm.IsActive = sm.IsActive;
                        bMSContext.SalesMan.Add(smm);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = smm.Id });
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
        [Route("/api/deleteSalesManById")]
        public object deleteSalesManById(long id)
        {
            try
            {
                var sm = bMSContext.SalesMan.SingleOrDefault(u => u.Id == id);
                if (sm != null)
                {
                    bMSContext.SalesMan.Remove(sm);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = sm.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getSalesManById")]
        public IEnumerable<SalesMan> getSalesManById(long id)
        {
            return bMSContext.SalesMan.Where(u => u.Id == id).ToList();
        }
    }
}
