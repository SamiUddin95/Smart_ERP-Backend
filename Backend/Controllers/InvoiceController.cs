using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Backend.Model;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]

    public class InvoiceController : Controller
    {

        private readonly IConfiguration _configuration;
        private static int invoiceNumber = 1;
        private const string invoicePrefix = "MM";
        public InvoiceController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        ERPContext bMSContext = new ERPContext();

        //[HttpGet]
        //[Route("/api/getAllInvoicedetails")]
        //public IEnumerable<Invoice> getAllCustomers()
        //{

        //    return bMSContext.Invoice.ToList();
        //}

        //[HttpGet]
        //[Route("/api/getAllInvoicedetails")]
        //public IEnumerable<InvoiceModel> getAllCustomers()
        //{
        //    List<InvoiceModel> l_invoice = new List<InvoiceModel>();

        //    var inv = bMSContext.Invoice.ToList();
        //    foreach (var invoice in inv)
        //    {
        //        InvoiceModel model = new InvoiceModel
        //        {
        //            Id = invoice.Id,
        //            Date = invoice.Date,
        //            Invoice1 = invoice.Invoice1,
        //            Customer1 = bMSContext.CustomerDetails.Where(a => a.Id == invoice.CustomerName).Select(a => a.ContactPerson).FirstOrDefault(),
        //            Status = invoice.Status,
        //            DueDate = invoice.DueDate,
        //            Amount = invoice.Amount,
        //            BalanceDue = invoice.BalanceDue,

        //        };

        //        l_invoice.Add(model);
        //    }
        //    return l_invoice;
        //}

        static string GenerateInvoiceNumber()
        {
            string formattedInvoiceNumber = $"{invoicePrefix}-{invoiceNumber:D4}";
            invoiceNumber++; // Increment for the next invoice
            return formattedInvoiceNumber;
        }

        [HttpPost]
        [Route("/api/createInvoicedetails")]
        public object createInvoicedetails(Invoice invoice)
        {
            try
            {

                try
                {
                    var InvCheck = bMSContext.Invoice.SingleOrDefault(u => u.Id == invoice.Id);
                    var duedte = bMSContext.CustomerDetails.SingleOrDefault(u => u.Id == invoice.CustomerName).PaymentTerms;
                    if (InvCheck != null)
                    {
                        InvCheck.Id = invoice.Id;
                        InvCheck.Date = invoice.Date;
                        InvCheck.Invoice1 = invoice.Invoice1;
                        InvCheck.CustomerName = invoice.CustomerName;
                        InvCheck.Status = "UN-PAID";
                        if (duedte == 1)
                        {
                            var cdate = System.DateTime.Now;
                            var ad15 = Convert.ToDateTime(cdate).AddDays(15);
                            var fdate = ad15.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = fdate;
                        }
                        else if (duedte == 2)
                        {
                            var cdate = System.DateTime.Now;
                            var ad30 = Convert.ToDateTime(cdate).AddDays(30);
                            var fdate = ad30.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = fdate;
                        }
                        else if (duedte == 3)
                        {
                            var cdate = System.DateTime.Now;
                            var ad45 = Convert.ToDateTime(cdate).AddDays(45);
                            var fdate = ad45.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = fdate;
                        }
                        else if (duedte == 4)
                        {
                            var cdate = System.DateTime.Now;
                            var ad60 = Convert.ToDateTime(cdate).AddDays(60);
                            var fdate = ad60.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = fdate;
                        }
                        else if (duedte == 5)
                        {
                            var cdate = System.DateTime.Now;
                            var ad90 = Convert.ToDateTime(cdate).AddDays(90);
                            var fdate = ad90.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = fdate;
                        }
                        else if (duedte == 6)
                        {
                            var cdate = System.DateTime.Now;
                            var dor = cdate.ToString("MM/dd/yyyy");
                            InvCheck.DueDate = dor;

                        }
                        else if (duedte == 7)
                        {
                            var cdate = DateTime.Now;
                            var eom = cdate.ToString("MM/dd/yyyy");

                            var dte = DateTime.Now.ToString("MM/dd/yyyy");
                            var syear = dte.Split('/');
                            int year = Convert.ToInt32(syear[2]);
                            int month = Convert.ToInt32(syear[1]);

                            int daysInMonth = DateTime.DaysInMonth(year, month);

                            var eomdte = eom.Split("/");
                            int eom1 = Convert.ToInt32(eomdte[1]);

                            var EndOfMonth = daysInMonth - eom1;

                            var fdte = cdate.AddDays(EndOfMonth);
                            InvCheck.DueDate = fdte.ToString("MM/dd/yyyy");


                        }
                        InvCheck.Qty = invoice.Qty;
                        InvCheck.UnitPrice = invoice.UnitPrice;
                        InvCheck.Amount = InvCheck.Qty * InvCheck.UnitPrice;

                        InvCheck.BalanceDue = InvCheck.Amount;//invoice.BalanceDue;
                        bMSContext.Invoice.Update(InvCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = InvCheck.Id });
                    }
                    else
                    {
                        Invoice invice = new Invoice();
                        invice.Id = invoice.Id;
                        invice.Date = invoice.Date;
                        invice.Invoice1 = GenerateInvoiceNumber();//invoice.Invoice1;
                        invice.CustomerName = invoice.CustomerName;
                        invice.Status = "UN-PAID";
                        //Duedate
                        if (duedte == 1)
                        {
                            var cdate = System.DateTime.Now;
                            var ad15 = Convert.ToDateTime(cdate).AddDays(15);
                            var fdate = ad15.ToString("MM/dd/yyyy");
                            invice.DueDate = fdate;
                        }
                        else if (duedte == 2)
                        {
                            var cdate = System.DateTime.Now;
                            var ad30 = Convert.ToDateTime(cdate).AddDays(30);
                            var fdate = ad30.ToString("MM/dd/yyyy");
                            invice.DueDate = fdate;
                        }
                        else if (duedte == 3)
                        {
                            var cdate = System.DateTime.Now;
                            var ad45 = Convert.ToDateTime(cdate).AddDays(45);
                            var fdate = ad45.ToString("MM/dd/yyyy");
                            invice.DueDate = fdate;
                        }
                        else if (duedte == 4)
                        {
                            var cdate = System.DateTime.Now;
                            var ad60 = Convert.ToDateTime(cdate).AddDays(60);
                            var fdate = ad60.ToString("MM/dd/yyyy");
                            invice.DueDate = fdate;
                        }
                        else if (duedte == 5)
                        {
                            var cdate = System.DateTime.Now;
                            var ad90 = Convert.ToDateTime(cdate).AddDays(90);
                            var fdate = ad90.ToString("MM/dd/yyyy");
                            invice.DueDate = fdate;
                        }
                        else if (duedte == 6)
                        {
                            var cdate = System.DateTime.Now;
                            var dor = cdate.ToString("MM/dd/yyyy");
                            invice.DueDate = dor;

                        }
                        else if (duedte == 7)
                        {
                            var cdate = DateTime.Now;
                            var eom = cdate.ToString("MM/dd/yyyy");

                            var dte = DateTime.Now.ToString("MM/dd/yyyy");
                            var syear = dte.Split('/');
                            int year = Convert.ToInt32(syear[2]);
                            int month = Convert.ToInt32(syear[1]);

                            int daysInMonth = DateTime.DaysInMonth(year, month);

                            var eomdte = eom.Split("/");
                            int eom1 = Convert.ToInt32(eomdte[1]);

                            var EndOfMonth = daysInMonth - eom1;

                            var fdte = cdate.AddDays(EndOfMonth);
                            invice.DueDate = fdte.ToString("MM/dd/yyyy");


                        }
                        invice.Qty = invoice.Qty;
                        invice.UnitPrice = invoice.UnitPrice;
                        invice.Amount = invice.Qty * invice.UnitPrice;
                        invice.BalanceDue = invice.Amount;
                        bMSContext.Invoice.Add(invice);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = invoice.Id });
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
        [Route("/api/deleteInvoicedetailsById")]
        public object deleteInvoiceById(long id)
        {
            try
            {
                var inv = bMSContext.Invoice.SingleOrDefault(u => u.Id == id);
                if (inv != null)
                {
                    bMSContext.Invoice.Remove(inv);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = inv.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getInvoicedetailsById")]
        public IEnumerable<Invoice> getCustomerById(long id)
        {
            return bMSContext.Invoice.Where(u => u.Id == id).ToList();
        }

        [HttpGet]
        [Route("/api/getAllInvoicedetailsbyid")]
        public IEnumerable<Invoice> getAllInvoicedetailsbyid(int id)
        {
            List<Invoice> l_invoice = new List<Invoice>();

            var inv = bMSContext.Invoice.ToList();
            foreach (var invoice in inv)
            {
                Invoice model = new Invoice
                {
                    Id = invoice.Id,
                    Date = invoice.Date,
                    Invoice1 = invoice.Invoice1,
                    //Customer1 = bMSContext.CustomerDetails.Where(a => a.Id == invoice.CustomerName).Select(a => a.ContactPerson).FirstOrDefault(),
                    Status = invoice.Status,
                    DueDate = invoice.DueDate,
                    Amount = invoice.Amount,
                    BalanceDue = invoice.BalanceDue,

                };

                l_invoice.Add(model);
            }
            return l_invoice;
        }

        [HttpGet]
        [Route("/api/getInvoicedetailsByCustomerId")]
        public IEnumerable<CustInvoice> getInvoicedetailsByCustomerId(int id)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<CustInvoice> result = new List<CustInvoice>();
            string query = "select * from dbo.vw_cust_invoice where 1=1";
            if (id>0)
                query =query+ " and Id="+id;
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
                            result.Add(new CustInvoice
                            {
                                Id = sdr["Id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["Id"]),
                                Invoice = sdr["Invoice#"].ToString(),
                                Bill_To = sdr["Bill_To"].ToString(),
                                Ship_To = sdr["Ship_To"].ToString(),
                                Contact_Person = sdr["Contact_Person"].ToString(),
                                Email= sdr["Email"].ToString(),
                                Phone= sdr["Phone"].ToString(),
                                Date= sdr["Date"].ToString(),
                                Qty = sdr["Qty"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["Qty"]),
                                Unit_Price= sdr["Unit_Price"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["Unit_Price"]),
                                Particulars = sdr["Particulars"].ToString(),

                            });
                        };
                    }
                }
            }
                return result;
        }

        [HttpGet]
        [Route("/api/getCustomerLedgerByCustomerId")]
        public IEnumerable<CustLedger> getCustomerLedgerByCustomerId(int id)
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<CustLedger> result = new List<CustLedger>();
            string query = "select * from dbo.vw_cust_ledger where 1=1";
            if (id > 0)
                query = query + " and Id=" + id;
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
                            result.Add(new CustLedger
                            {
                                Id = sdr["Id"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["Id"]),
                                Invoice = sdr["Invoice#"].ToString(),
                                Bill_To = sdr["Bill_To"].ToString(),
                                Ship_To = sdr["Ship_To"].ToString(),
                                Contact_Person = sdr["Contact_Person"].ToString(),
                                Email = sdr["Email"].ToString(),
                                Phone = sdr["Phone"].ToString(),
                                Date = sdr["Date"].ToString(),
                                Qty = sdr["Qty"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["Qty"]),
                                Unit_Price = sdr["Unit_Price"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["Unit_Price"]),
                                Particulars = sdr["Particulars"].ToString(),
                                BalanceDue = sdr["BalanceDue"] == DBNull.Value ? 0 : Convert.ToDecimal(sdr["BalanceDue"]),

                            });
                        };
                    }
                }
            }
            return result;
        }

    }
}
