using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Backend.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class TIllController : Controller
    {
        private readonly IConfiguration _configuration;
        public TIllController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        ERPContext bMSContext = new ERPContext();

        [HttpGet]
        [Route("/api/getAllTodaysCashIn")]
        public IEnumerable<SaleCash> getAllTodaysCashIn()
        {
            return bMSContext.SaleCash.ToList().Where(x=>x.CashInDateTime==Convert.ToString(DateTime.Now.Date.ToString("yyyy-MM-dd"))).OrderByDescending(x => x.Id);
        }

        [HttpGet]
        [Route("/api/getAllTodaysCashOut")]
        public IEnumerable<SaleCash> getAllTodaysCashOut()
        {
            return bMSContext.SaleCash.ToList().Where(x => x.CashOutDateTime == Convert.ToString(DateTime.Now.Date.ToString("yyyy-MM-dd"))).OrderByDescending(x => x.Id);
        }

        [HttpGet]
        [Route("/api/getAllTodaysCreditSale")]
        public IEnumerable<dynamic> getAllTodaysCreditSale()
        {
            return bMSContext.Sale.ToList().OrderByDescending(x => x.Id);
        }
    }
}
