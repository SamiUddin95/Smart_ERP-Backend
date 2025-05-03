using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Backend.Model;
using System.Globalization;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class MinimunQuantityController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        [HttpPost]
        [Route("/api/createMinimumQty")]
        public object createMinimumQty(List<MinimumQty> minimumQtyList)
        {
            try
            {
                foreach (var minimumQty in minimumQtyList)
                {
                    var minmumchk = bMSContext.MinimumQty
                        .SingleOrDefault(u => u.Barcode == minimumQty.Barcode); // use Barcode or ID for matching

                    if (minmumchk != null)
                    {
                        minmumchk.ItemName = minimumQty.ItemName;
                        minmumchk.CurrentStock = minimumQty.CurrentStock;
                        minmumchk.NetRate = minimumQty.NetRate;
                        minmumchk.MinimumQty1 = minimumQty.MinimumQty1;
                        minmumchk.UpdatedAt = DateTime.UtcNow;
                        minmumchk.UpdatedBy = minimumQty.UpdatedBy;

                        bMSContext.MinimumQty.Update(minmumchk);
                    }
                    else
                    {
                        var latestSNo = bMSContext.MinimumQty
                            .OrderByDescending(a => a.Sno)
                            .FirstOrDefault();

                        long? newSNoNumber = (latestSNo != null) ? latestSNo.Sno + 1 : 1;

                        MinimumQty qty = new MinimumQty
                        {
                            Sno = newSNoNumber,
                            Barcode = minimumQty.Barcode,
                            ItemName = minimumQty.ItemName,
                            CurrentStock = minimumQty.CurrentStock,
                            NetRate = minimumQty.NetRate,
                            MinimumQty1 = minimumQty.MinimumQty1,
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = minimumQty.UpdatedBy
                        };

                        bMSContext.MinimumQty.Add(qty);
                    }
                }

                bMSContext.SaveChanges();

                return JsonConvert.SerializeObject(new { success = true, message = "All items processed successfully." });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        [Route("/api/GetItemsBySupplier")]
        public IEnumerable<dynamic> GetItemsBySupplier(int PartyId, string PartyName)
        {
            if (PartyName == "Brand")
            {
                var getItem = (from item in bMSContext.Item
                               where item.BrandId == PartyId
                               select new
                               {
                                   id = item.Id,
                                   barcode = item.AliasName,
                                   itemName = item.ItemName,
                                   netCost = item.PurchasePrice,
                                   currentStock = bMSContext.PurchaseDetail
                                                   .Where(po => po.ItemName == item.ItemName)
                                                   .Select(po => po.NetQuantity)
                                                   .FirstOrDefault()
                               }).ToList();
                var result = new
                {
                    getItem = getItem
                };

                yield return JsonConvert.SerializeObject(result);
            }
            else if (PartyName == "Class")
            {
                var getItem = (from item in bMSContext.Item
                               where item.ClassId == PartyId
                               select new
                               {
                                   id = item.Id,
                                   barcode = item.AliasName,
                                   itemName = item.ItemName,
                                   netCost = item.PurchasePrice,
                                   currentStock = bMSContext.PurchaseDetail
                                                   .Where(po => po.ItemName == item.ItemName)
                                                   .Select(po => po.NetQuantity)
                                                   .FirstOrDefault()
                               }).ToList();
                var result = new
                {
                    getItem = getItem
                };

                yield return JsonConvert.SerializeObject(result);
            }

            else if (PartyName == "Category")
            {
                var getItem = (from item in bMSContext.Item
                               where item.CategoryId == PartyId
                               select new
                               {
                                   id = item.Id,
                                   barcode = item.AliasName,
                                   itemName = item.ItemName,
                                   netCost = item.PurchasePrice,
                                   currentStock = bMSContext.PurchaseDetail
                                                   .Where(po => po.ItemName == item.ItemName)
                                                   .Select(po => po.NetQuantity)
                                                   .FirstOrDefault()
                               }).ToList();
                var result = new
                {
                    getItem = getItem
                };

                yield return JsonConvert.SerializeObject(result);
            }
            else if (PartyName == "Manufacture")
            {
                var getItem = (from item in bMSContext.Item
                               where item.ManufacturerId == PartyId
                               select new
                               {
                                   id = item.Id,
                                   barcode = item.AliasName,
                                   itemName = item.ItemName,
                                   netCost = item.PurchasePrice,
                                   currentStock = bMSContext.PurchaseDetail
                                                   .Where(po => po.ItemName == item.ItemName)
                                                   .Select(po => po.NetQuantity)
                                                   .FirstOrDefault()
                               }).ToList();
                var result = new
                {
                    getItem = getItem
                };

                yield return JsonConvert.SerializeObject(result);
            }

        }

    }
}
