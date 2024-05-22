using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class PaymentReceivedController : Controller
    {
        private static int ReceiptNumber = 1;
        private const string ReceiptPrefix = "PMT";
        ERPContext bMSContext = new ERPContext();

        //[HttpGet]
        //[Route("/api/getAllReceivedPaymentsdetails")]
        //public IEnumerable<ReceivedPayments> getAllReceivedPayments()
        //{
        //    return bMSContext.ReceivedPayments.ToList();
        //}

        static string GenerateReceiptNumber()
        {
            string formattedReceiptNumber = $"{ReceiptPrefix}{ReceiptNumber:D8}";
            ReceiptNumber++; // Increment for the next invoice
            return formattedReceiptNumber;
        }

        //[HttpGet]
        //[Route("/api/getAllReceivedPaymentsdetails")]
        //public IEnumerable<ReceiptModel> getAllReceivedPayments()
        //{
        //    List<ReceiptModel> l_receipt = new List<ReceiptModel>();

        //    var rm = bMSContext.ReceivedPayments.ToList();
        //    foreach (var receipt in rm)
        //    {
        //        ReceiptModel model = new ReceiptModel
        //        {
        //            Id = receipt.Id,
        //            Date = receipt.Date.ToString(),
        //            ReceiptNo = receipt.ReceiptNo,
        //            customername1 = bMSContext.CustomerDetails.Where(a => a.Id == receipt.CustomerName).Select(a => a.ContactPerson).FirstOrDefault(),
        //            invoice1 = bMSContext.Invoice.Where(a => a.Id == receipt.InvoiceNo).Select(a => a.Invoice1).FirstOrDefault(),
        //            type1 = bMSContext.PaymentType.Where(a=>a.Id == receipt.Type).Select(a=>a.PaymentType1).FirstOrDefault(),
        //            mode1 = bMSContext.PaymentMode.Where(a => a.Id == receipt.Mode).Select(a => a.PaymentMode1).FirstOrDefault(),
        //            Amount = receipt.Amount,

        //        };

        //        l_receipt.Add(model);
        //    }
        //    return l_receipt;
        //}

        [HttpPost]
        [Route("/api/createReceivedPayments")]
        public object createReceivedPayments(ReceivedPayments receivedPayments)
        {
            try
            {

                try
                {
                    var recpay = bMSContext.ReceivedPayments.SingleOrDefault(u => u.Id == receivedPayments.Id);
                    Invoice invoice = new Invoice();
                    var amountchk = bMSContext.Invoice.SingleOrDefault(u => u.Id == receivedPayments.InvoiceNo);
                    //var balancedue = bMSContext.Invoice.SingleOrDefault(u => u.Id == receivedPayments.Amount);
                    if (recpay != null)
                    {
                        recpay.Id = receivedPayments.Id;
                        recpay.Date = receivedPayments.Date;
                        recpay.ReceiptNo = receivedPayments.ReceiptNo;//GenerateReceiptNumber();
                        recpay.PaymentNo = receivedPayments.PaymentNo;
                        recpay.Type = receivedPayments.Type;
                        recpay.ReferenceNumber = receivedPayments.ReferenceNumber;
                        recpay.CustomerName = receivedPayments.CustomerName;
                        recpay.InvoiceNo = receivedPayments.InvoiceNo;
                        recpay.Mode = receivedPayments.Mode;
                        recpay.Amount = receivedPayments.Amount;
                        recpay.UnusedAmount = receivedPayments.UnusedAmount;
                        if (recpay.Amount == amountchk.Amount)
                        {
                            amountchk.Status = "PAID";
                            amountchk.BalanceDue = Convert.ToInt64(0.00);
                        }
                        else if (recpay.Amount != amountchk.Amount)
                        {
                            amountchk.Status = "PARTIALLY PAID";
                            amountchk.BalanceDue = Convert.ToInt32(amountchk.Amount - recpay.Amount);
                        }

                        bMSContext.ReceivedPayments.Update(recpay);
                        bMSContext.Invoice.Update(amountchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = recpay.Id });
                    }
                    else
                    {
                        ReceivedPayments received = new ReceivedPayments();
                        received.Id = receivedPayments.Id;
                        received.Date = receivedPayments.Date;
                        received.ReceiptNo = GenerateReceiptNumber();
                        received.PaymentNo = receivedPayments.PaymentNo;
                        received.Type = receivedPayments.Type;
                        received.ReferenceNumber = receivedPayments.ReferenceNumber;
                        received.CustomerName = receivedPayments.CustomerName;
                        received.InvoiceNo = receivedPayments.InvoiceNo;
                        received.Mode = receivedPayments.Mode;
                        received.Amount = receivedPayments.Amount;
                        received.UnusedAmount = receivedPayments.UnusedAmount;
                        if (received.Amount == amountchk.Amount)
                        {
                            amountchk.Status = "PAID";
                            amountchk.BalanceDue = Convert.ToInt64(0.00);
                        }
                        else if (received.Amount != amountchk.Amount)
                        {
                            amountchk.Status = "PARTIALLY PAID";
                            amountchk.BalanceDue = Convert.ToInt32(amountchk.Amount - received.Amount);
                        }
                        bMSContext.ReceivedPayments.Add(received);
                        bMSContext.Invoice.Update(amountchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = receivedPayments.Id });
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
        [Route("/api/deleteReceivedPaymentsById")]
        public object deleteReceivedPaymentsById(long id)
        {
            try
            {
                var rec = bMSContext.ReceivedPayments.SingleOrDefault(u => u.Id == id);
                if (rec != null)
                {
                    bMSContext.ReceivedPayments.Remove(rec);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = rec.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getReceivedPaymentsById")]
        public IEnumerable<ReceivedPayments> getReceivedPaymentById(long id)
        {
            return bMSContext.ReceivedPayments.Where(u => u.Id == id).ToList();
        }

        [HttpGet]
        [Route("/api/getAllPaymentTypes")]
        public IEnumerable<PaymentType> getAllPaymentTypes()
        {
            return bMSContext.PaymentType.ToList();
        }

        [HttpGet]
        [Route("/api/getAllPaymentModes")]
        public IEnumerable<PaymentMode> getAllPaymentModes()
        {
            return bMSContext.PaymentMode.ToList();
        }

        [HttpGet]
        [Route("/api/getbyinvoicedetailsbycustomer")]
        public IEnumerable<Invoice> getbyinvoicedetailsbycustomer(string cust)
        {
            var test= bMSContext.Invoice.Where(u => u.CustomerName.ToString() == cust).ToList(); 
            return bMSContext.Invoice.Where(u => u.CustomerName.ToString() == cust).ToList();
        }
    }
}
