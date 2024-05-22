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

    public class CustomerController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        

        [HttpGet]
        [Route("/api/getAllCustomersdetails")]
        public IEnumerable<CustomerDetails> getAllCustomers()
        {
            return bMSContext.CustomerDetails.ToList();
        }

        [HttpPost]
        [Route("/api/createCustomerdetails")]
        public object createCustomerdetails(CustomerDetails customer)
        {
            try
            {

                try
                {
                    var cusCheck = bMSContext.CustomerDetails.SingleOrDefault(u => u.Id == customer.Id);
                    if (cusCheck != null)
                    {
                        cusCheck.Id = customer.Id;
                        cusCheck.Business = customer.Business;
                        cusCheck.Individual = customer.Individual;
                        cusCheck.Code = customer.Code;
                        cusCheck.ShopName = customer.ShopName;
                        cusCheck.ShopNumber = customer.ShopNumber;
                        cusCheck.ContactPerson = customer.ContactPerson;
                        cusCheck.BillTo = customer.BillTo;
                        cusCheck.ShipTo = customer.ShipTo;
                        cusCheck.Email = customer.Email;
                        cusCheck.Phone = customer.Phone;
                        cusCheck.CustomerBalance = customer.CustomerBalance;
                        cusCheck.PaymentTerms = customer.PaymentTerms;
                        cusCheck.BankDetails = customer.BankDetails;
                        cusCheck.Facebook = customer.Facebook;
                        cusCheck.Instagram = customer.Instagram;
                        cusCheck.TikTok = customer.TikTok;
                        cusCheck.Linkedin = customer.Linkedin;
                        cusCheck.Twitter = customer.Twitter;
                        cusCheck.Website = customer.Website;
                        bMSContext.CustomerDetails.Update(cusCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = cusCheck.Id });
                    }
                    else
                    {
                        CustomerDetails customerDetails = new CustomerDetails();
                        customerDetails.Id = customer.Id;
                        customerDetails.Business = customer.Business;
                        customerDetails.Individual = customer.Individual;
                        customerDetails.Code = customer.Code;
                        customerDetails.ShopNumber = customer.ShopNumber;
                        customerDetails.ContactPerson = customer.ContactPerson;
                        customerDetails.ShopName = customer.ShopName;
                        customerDetails.BillTo = customer.BillTo;
                        customerDetails.ShipTo = customer.ShipTo;
                        customerDetails.Email = customer.Email;
                        customerDetails.Phone = customer.Phone;
                        customerDetails.CustomerBalance = customer.CustomerBalance;
                        customerDetails.PaymentTerms = customer.PaymentTerms;
                        customerDetails.BankDetails = customer.BankDetails;
                        customerDetails.Facebook = customer.Facebook;
                        customerDetails.Instagram = customer.Instagram;
                        customerDetails.TikTok = customer.TikTok;
                        customerDetails.Linkedin = customer.Linkedin;
                        customerDetails.Twitter = customer.Twitter;
                        customerDetails.Website = customer.Website;
                        bMSContext.CustomerDetails.Add(customerDetails);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = customerDetails.Id });
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
        [Route("/api/deleteCustomerdetailsById")]
        public object deleteCustomerById(long id)
        {
            try
            {
                var cus = bMSContext.CustomerDetails.SingleOrDefault(u => u.Id == id);
                if (cus != null)
                {
                    bMSContext.CustomerDetails.Remove(cus);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = cus.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getCustomerdetailsById")]
        public IEnumerable<CustomerDetails> getCustomerById(long id)
        {
            return bMSContext.CustomerDetails.Where(u => u.Id == id).ToList();
        }

        [HttpGet]
        [Route("/api/getAllPaymentTerms")]
        public IEnumerable<PaymentTerms> getAllPaymentTerms()
        {
            return bMSContext.PaymentTerms.ToList();
        }
    }
}
