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
    public class MinimunQuantityController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        [HttpPost]
        [Route("/api/createMinimumQty")]
        public object createMinimumQty(MinimumQty minimumQty)
        {

            try
            {
                try
                {
                    var minmumchk = bMSContext.MinimumQty.SingleOrDefault(u => u.Id == minimumQty.Id);
                    if (minmumchk != null)
                    {
                        minmumchk.Id = minimumQty.Id;
                        minmumchk.Barcode = minimumQty.Barcode;
                        minmumchk.ItemName = minimumQty.ItemName;
                        minmumchk.CurrentStock = minimumQty.CurrentStock;   
                        minmumchk.NetRate = minimumQty.NetRate;
                        minmumchk.MinimumQty1 = minimumQty.MinimumQty1;
                        minmumchk.UpdatedAt = DateTime.UtcNow;
                        minmumchk.UpdatedBy = minimumQty.UpdatedBy;
                        bMSContext.MinimumQty.Update(minmumchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = minmumchk.Id });
                    }
                    else
                    {
                        var latestSNo = bMSContext.MinimumQty
                        .OrderByDescending(a => a.Sno)
                        .FirstOrDefault();

                        long? newSNoNumber = 1;

                        if (latestSNo != null)
                        {
                            newSNoNumber = latestSNo.Sno + 1;
                        }
                        MinimumQty qty = new MinimumQty();
                        qty.Sno = newSNoNumber;
                        qty.Barcode = minimumQty.Barcode;
                        qty.ItemName = minimumQty.ItemName;
                        qty.CurrentStock = minimumQty.CurrentStock;
                        qty.NetRate = minimumQty.NetRate;
                        qty.MinimumQty1 = minimumQty.MinimumQty1;
                        qty.CreatedAt = DateTime.UtcNow;
                        qty.CreatedBy = minimumQty.UpdatedBy;
                        bMSContext.MinimumQty.Add(qty);
                        bMSContext.SaveChanges();
                        
                        return JsonConvert.SerializeObject(new { id = qty.Id });
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
