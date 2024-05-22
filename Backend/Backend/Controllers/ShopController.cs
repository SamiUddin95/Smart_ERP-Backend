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
    public class ShopController : Controller
    {

        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllShops")]
        public IEnumerable<Shop> getAllShops()
        {
            return bMSContext.Shop.ToList();
        }
        [HttpGet]
        [Route("/api/getAllAgreementTypes")]
        public IEnumerable<AgreementType> getAllAgreementTypes()
        {
            return bMSContext.AgreementType.ToList();
        }
        [HttpGet]
        [Route("/api/getAllShopsType")]
        public IEnumerable<ShopType> getAllShopsType()
        {
            return bMSContext.ShopType.ToList();
        }
        [HttpPost]
        [Route("/api/createShop")]
        public object createShop(Shop shop)
        {

            try
            {
                try
                {
                    var shpCheck = bMSContext.Shop.SingleOrDefault(u => u.ShopId == shop.ShopId);
                    if (shpCheck != null)
                    {
                        shpCheck.ShopId = shop.ShopId;
                        shpCheck.ShopName = shop.ShopName;
                        shpCheck.ShopSize= shop.ShopSize;
                        shpCheck.ShopLocation = shop.ShopLocation;
                        shpCheck.ShopTypeId = shop.ShopTypeId;
                        shpCheck.AgreementStartDate = shop.AgreementStartDate;
                        //shpCheck.RentDecided = shop.RentDecided;
                        //shpCheck.Balance = shop.Balance;
                        bMSContext.Shop.Update(shpCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = shpCheck.ShopId });
                    }
                    else
                    {
                        Shop shp = new Shop();
                        shp.ShopId = shop.ShopId;
                        shp.ShopName = shop.ShopName;
                        shp.ShopSize = shop.ShopSize;
                        shp.ShopLocation = shop.ShopLocation;
                        shp.ShopTypeId = shop.ShopTypeId;
                        shp.AgreementStartDate = shop.AgreementStartDate;
                        //shp.RentDecided = shop.RentDecided;
                        //shp.Balance = shop.Balance;
                        bMSContext.Shop.Add(shp);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = shp.ShopId});
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
        [Route("/api/deleteShopById")]
        public object deleteShopById(long id)
        {
            try
            {
                var shp = bMSContext.Shop.SingleOrDefault(u => u.ShopId == id);
                if (shp != null)
                {
                    bMSContext.Shop.Remove(shp);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = shp.ShopId });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getShopById")]
        public IEnumerable<Shop> getShopById(long id)
        {
            return bMSContext.Shop.Where(u => u.ShopId == id).ToList();
        }
        [HttpGet]
        [Route("/api/getAllMonths")]
        public IEnumerable<Month> getAllMonths()
        {
            return bMSContext.Month.ToList();
        }
    }
}
