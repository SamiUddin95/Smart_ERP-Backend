using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Backend.Models;
using Backend.Model;
using Backend.Model.FilterModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class ReportController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        private readonly IConfiguration _configuration;
        public ReportController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        [HttpPost]
        [Route("/api/getUnRentedShops")]
        public IEnumerable<UnRentedShops> getUnRentedShops(FilterUnPaidRentReportModel filter)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<UnRentedShops> result = new List<UnRentedShops>();
            string query = "SELECT * FROM vw_unrented_shops WHERE 1=1";
            if(filter.month_id!=0)
                query=query+" and month_id="+filter.month_id;
            if (filter.shop_id != 0)
                query = query + " and shop_id=" + filter.shop_id;
            using (SqlConnection con = new SqlConnection(constr))
            {                
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            result.Add(new UnRentedShops
                            {
                                 month_id= sdr["month_id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["month_id"]),
                                 shop_id= sdr["shop_id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["shop_id"]),
                                 shop_name= sdr["shop_name"].ToString(),
                                 month_name= sdr["month_name"].ToString(),
                            });
                        };
                    }
                    con.Close();
                }
            }
            return result;

        }
        [HttpPost]
        [Route("/api/getRentedShops")]
        public IEnumerable<RentedShops> getRentedShops(FilterPaidRentReportModel filter)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<RentedShops> result = new List<RentedShops>();
            string query = "SELECT * FROM vw_rented_shops where 1=1";
            if (filter.month_id != 0)
                query = query + " and month_id=" + filter.month_id;
            if (filter.shop_id != 0)
                query = query + " and shop_id=" + filter.shop_id;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            result.Add(new RentedShops
                            {
                                month_id = sdr["month_id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["month_id"]),
                                shop_id = sdr["shop_id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["shop_id"]),
                                rent = sdr["rent"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["rent"]),
                                electricity_bill = sdr["electricity_bill"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["electricity_bill"]),
                                maintenance = sdr["maintenance"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["maintenance"]),
                                shop_name = sdr["shop_name"].ToString(),
                                month_name =sdr["month_name"].ToString()
                            });
                        };
                    }
                    con.Close();
                }
            }
            return result;
        }

        [HttpPost]
        [Route("/api/getIncomeReport")]
        public IEnumerable<IncomeReport> getIncomeReport(FilterIncomeReportModel filter)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<IncomeReport> result = new List<IncomeReport>();
            string query = "SELECT * FROM vw_income WHERE 1=1";
            if (filter.month_id != 0)
                query = query + " and month_id=" + filter.month_id;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            result.Add(new IncomeReport
                            {
                                totalAmount = sdr["totalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalAmount"]),
                                totalRent = sdr["totalRent"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalRent"]),
                                totalElctricityBill = sdr["totalElctricityBill"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalElctricityBill"]),
                                totalMaintenance = sdr["totalMaintenance"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalMaintenance"]),
                            });
                        };
                    }
                    con.Close();
                }
            }
            return result;

        }

        [HttpGet]
        [Route("/api/getIncomeReport")]
        public IEnumerable<IncomeReport> getInvoiceReport(string custId,StringInfo dateFrom,string dateTo)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<IncomeReport> result = new List<IncomeReport>();
            string query = "SELECT * FROM vw_cust_invoice WHERE 1=1"; 

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            result.Add(new IncomeReport
                            {
                                totalAmount = sdr["totalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalAmount"]),
                                totalRent = sdr["totalRent"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalRent"]),
                                totalElctricityBill = sdr["totalElctricityBill"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalElctricityBill"]),
                                totalMaintenance = sdr["totalMaintenance"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["totalMaintenance"]),
                            });
                        };
                    }
                    con.Close();
                }
            }
            return result;

        }
    }
}
