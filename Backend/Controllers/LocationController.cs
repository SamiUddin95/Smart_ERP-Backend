using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class LocationController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        [HttpPost]
        [Route("/api/createLocation")]
        public object createLocation(Location location)
        {

            try
            {
                try
                {
                    var locchk = bMSContext.Location.SingleOrDefault(u => u.Id == location.Id);
                    if (locchk != null)
                    {

                        locchk.Id = location.Id;
                        locchk.Name = location.Name;
                        locchk.Address = location.Address;
                        locchk.Phonenumber = location.Phonenumber;
                        locchk.Email = location.Email;
                        locchk.RoyalityPercent = location.RoyalityPercent;
                        locchk.UpdatedAt = DateTime.Now;
                        locchk.UpdatedBy = location.UpdatedBy;
                        bMSContext.Location.Update(locchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = locchk.Id });
                    }
                    else
                    {
                        var latestSNo = bMSContext.Location
                        .OrderByDescending(a => a.Serialnumber)
                        .FirstOrDefault();

                        long? newSNoNumber = 1;

                        if (latestSNo != null)
                        {
                            newSNoNumber = latestSNo.Serialnumber + 1;
                        }
                        Location location1 = new Location();
                        location1.Serialnumber = newSNoNumber;
                        location1.Name = location.Name;
                        location1.Address = location.Address;
                        location1.Phonenumber = location.Phonenumber;
                        location1.Email = location.Email;
                        location1.RoyalityPercent = location.RoyalityPercent;
                        location1.CreatedAt = DateTime.Now;
                        location1.CreatedBy = location.CreatedBy;
                        bMSContext.Location.Add(location1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = location1.Id });
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
        [Route("/api/deleteLocationById")]
        public object deleteLocationById(int id)
        {
            try
            {
                var delloc = bMSContext.Location.SingleOrDefault(u => u.Id == id);
                if (delloc != null)
                {
                    bMSContext.Location.Remove(delloc);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delloc.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getLocationById")]
        public IEnumerable<Location> getLocationById(int id)
        {
            return bMSContext.Location.Where(u => u.Id == id).ToList();
        }

        [HttpGet]
        [Route("/api/getAllLocationdetailsFilterbased")]
        public IEnumerable<Location> getAllLocationdetailsFilterbased(string locationName, long sno)
        {
            var query = bMSContext.Location.AsQueryable();
            if (locationName != "All")
            {
                query = query.Where(i => i.Name.Contains(locationName));
            }
            if (sno > 0)
            {
                query = query.Where(i => i.Serialnumber == sno);
            }
            return query.ToList();
        }
    }
}
