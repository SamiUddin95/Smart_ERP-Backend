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
    public class AccountController : Controller
    {
        ERPContext bMSContext = new ERPContext(); 
        [HttpGet]
        [Route("/api/getAllAccountCategory")]
        public IEnumerable<dynamic> getAllAccountCategory()
        {
            var result = (from acc in bMSContext.AccCategory
                         join act in bMSContext.AccType on acc.AccountTypeId equals act.Id
                         select new
                         {
                             AccCategory = acc.Name,
                             AccType = act.Name,
                             Id = acc.Id,
                             Priority = acc.Priority,
                             ManualCode = acc.ManualCode,
                             name=acc.Name
                             
                         }).ToList();

            return result;
        }  
        [HttpPost]
        [Route("/api/createAccountCategory")]
        public object createAccountCategory(AccCategory accCategory)
        {

            try
            {
                try
                {
                    var accCatChk = bMSContext.AccCategory.SingleOrDefault(u => u.Id == accCategory.Id);
                    if (accCatChk != null)
                    {

                        accCatChk.Id = accCategory.Id; 
                        accCatChk.AccountTypeId = accCategory.AccountTypeId; 
                        accCatChk.Name = accCategory.Name;
                        accCatChk.Remarks = accCategory.Remarks;
                        accCatChk.CatNumber = accCategory.CatNumber;
                        accCatChk.ManualCode = accCategory.ManualCode;
                        accCatChk.Priority = accCategory.Priority;
                        accCatChk.UpdatedAt = DateTime.Now;
                        accCatChk.UpdatedBy = accCategory.UpdatedBy;
                        bMSContext.AccCategory.Update(accCatChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accCatChk.Id });
                    }
                    else
                    {
                        AccCategory accCat = new AccCategory();
                        accCat.Id = accCategory.Id;
                        accCat.AccountTypeId = accCategory.AccountTypeId;
                        accCat.Name = accCategory.Name;
                        accCat.ManualCode = accCategory.ManualCode;
                        accCat.Priority = accCategory.Priority;
                        accCat.Remarks = accCategory.Remarks;
                        accCat.CatNumber = accCategory.CatNumber;
                        accCat.CreatedAt = DateTime.Now;
                        accCat.CreatedBy = accCategory.CreatedBy;
                        bMSContext.AccCategory.Add(accCat);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accCat.Id });
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
        [Route("/api/deleteAccountCategoryById")]
        public object deleteAccountCategoryById(int id)
        {
            try
            {
                var accCat = bMSContext.AccCategory.SingleOrDefault(u => u.Id == id);
                if (accCat != null)
                {
                    bMSContext.AccCategory.Remove(accCat);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = accCat.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getAccountCategoryById")]
        public IEnumerable<AccCategory> getAccountCategoryById(int id)
        {
            return bMSContext.AccCategory.Where(u => u.Id == id).ToList();
        }



        [HttpGet]
        [Route("/api/getAllAccountType")]
        public IEnumerable<AccType> getAllAccountType()
        {
            return bMSContext.AccType.ToList();
        }
        [HttpPost]
        [Route("/api/createAccountType")]
        public object createAccountType(AccType accType)
        {

            try
            {
                try
                {
                    var accTypeChk = bMSContext.AccType.SingleOrDefault(u => u.Id == accType.Id);
                    if (accTypeChk != null)
                    {

                        accTypeChk.Id = accType.Id;
                        accTypeChk.Name = accType.Name;
                        accTypeChk.UpdatedAt = DateTime.Now;
                        accTypeChk.UpdatedBy = accType.UpdatedBy;
                        bMSContext.AccType.Update(accTypeChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accTypeChk.Id });
                    }
                    else
                    {
                        AccType accountType = new AccType();
                        accountType.Id = accType.Id;
                        accountType.Name = accType.Name;
                        accountType.CreatedAt = DateTime.Now;
                        accountType.CreatedBy = accType.CreatedBy;
                        bMSContext.AccType.Add(accountType);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accountType.Id });
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
        [Route("/api/deleteAccountTypeById")]
        public object deleteAccountTypeById(int id)
        {
            try
            {
                var accType = bMSContext.AccType.SingleOrDefault(u => u.Id == id);
                if (accType != null)
                {
                    bMSContext.AccType.Remove(accType);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = accType.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getAccountTypeById")]
        public IEnumerable<AccType> getAccountTypeById(int id)
        {
            return bMSContext.AccType.Where(u => u.Id == id).ToList();
        }



        [HttpGet]
        [Route("/api/getAllAccGroupCategory")]
        public IEnumerable<AccGroup> getAllAccGroupCategory()
        {

            //var result = (from purchase in bMSContext.Purchase
            //              join purchaseDetail in bMSContext.PurchaseDetail on purchase.Id equals purchaseDetail.PurchaseId
            //              select new
            //              {
            //                  purchaseId = purchase.Id,
            //                  vendorId = purchase.VendorId,
            //                  invoiceNo = purchase.InvoiceNo,
            //                  remarks = purchase.Remarks,
            //                  recentPurchasePrice = purchase.RecentPurchasePrice,
            //                  salePrice = purchase.SalePrice,
            //                  itemsQuantity = purchase.ItemsQuantity,
            //                  totalDiscount = purchase.TotalDiscount,
            //                  totalGst = purchase.TotalGst,
            //                  billTotal = purchase.BillTotal,
            //              }).ToList();

            //return result;
            //var result=(from AccGroupCategory in bMSContext.AccGroupCategory
            //    join AccCategory in bMSContext.AccCategory on AccGroupCategory.GroupCategoryId equals AccCategory.Id)
            return bMSContext.AccGroup.ToList();
        }
        //[HttpPost]
        //[Route("/api/createAccGroupCategory")]
        //public object createAccGroupCategory(AccGroupCategory accGrpCat)
        //{

        //    try
        //    {
        //        try
        //        {
        //            var accGrpCatChk = bMSContext.AccGroupCategory.SingleOrDefault(u => u.Id == accGrpCat.Id);
        //            if (accGrpCatChk != null)
        //            {

        //                accGrpCatChk.Id = accGrpCat.Id; 
        //                accGrpCatChk.Name = accGrpCat.Name;
        //                bMSContext.AccGroupCategory.Update(accGrpCatChk);
        //                bMSContext.SaveChanges();
        //                return JsonConvert.SerializeObject(new { id = accGrpCatChk.Id });
        //            }
        //            else
        //            {
        //                AccGroupCategory accountGrpCat = new AccGroupCategory();
        //                accountGrpCat.Id = accGrpCat.Id;
        //                accountGrpCat.Name = accGrpCat.Name;
        //                bMSContext.AccGroupCategory.Add(accountGrpCat);
        //                bMSContext.SaveChanges();
        //                return JsonConvert.SerializeObject(new { id = accountGrpCat.Id });
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            JsonConvert.SerializeObject(new { msg = ex.Message });
        //        }
        //        return JsonConvert.SerializeObject(new { msg = "Message" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        [HttpGet]
        [Route("/api/deleteAccGroupCategoryById")]
        public object deleteAccGroupCategoryById(int id)
        {
            try
            {
                var accGrpCat = bMSContext.AccGroup.SingleOrDefault(u => u.Id == id);
                if (accGrpCat != null)
                {
                    bMSContext.AccGroup.Remove(accGrpCat);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = accGrpCat.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getAccGroupCategoryById")]
        public IEnumerable<AccGroup> getAccGroupCategoryById(int id)
        {
            return bMSContext.AccGroup.Where(u => u.Id == id).ToList();
        }



        [HttpGet]
        [Route("/api/getAllAccGroup")]
        public IEnumerable<AccGroup> getAllAccGroup()
        {
            return bMSContext.AccGroup.ToList();
        }
        [HttpPost]
        [Route("/api/createAccGroup")]
        public object createAccGroup(AccGroup accGrp)
        {

            try
            {
                try
                {
                    var accGrpChk = bMSContext.AccGroup.SingleOrDefault(u => u.Id == accGrp.Id);
                    if (accGrpChk != null)
                    {

                        accGrpChk.Id = accGrp.Id;
                        accGrpChk.AccountTypeId = accGrp.AccountTypeId;
                        accGrpChk.AccountCategoryId = accGrp.AccountCategoryId;
                        accGrpChk.Name = accGrp.Name;
                        accGrpChk.Remarks = accGrp.Remarks;
                        accGrpChk.GroupNumber = accGrp.GroupNumber;
                        accGrpChk.ManualCode = accGrp.ManualCode;
                        accGrpChk.Priority = accGrp.Priority;
                        accGrpChk.UpdatedAt = DateTime.Now;
                        accGrpChk.UpdatedBy = accGrp.UpdatedBy;
                        bMSContext.AccGroup.Update(accGrpChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accGrpChk.Id });
                    }
                    else
                    {
                        AccGroup accountGrp = new AccGroup();
                        accountGrp.Id = accGrp.Id;
                        accountGrp.AccountTypeId = accGrp.AccountTypeId;
                        accountGrp.AccountCategoryId = accGrp.AccountCategoryId;
                        accountGrp.Name = accGrp.Name;
                        accountGrp.ManualCode = accGrp.ManualCode;
                        accountGrp.Priority = accGrp.Priority;
                        accountGrp.Remarks = accGrp.Remarks;
                        accountGrp.GroupNumber = accGrp.GroupNumber;
                        accountGrp.CreatedAt = DateTime.Now;
                        accountGrp.CreatedBy = accGrp.CreatedBy;
                        bMSContext.AccGroup.Add(accountGrp);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accountGrp.Id });
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
        [Route("/api/deleteAccGroupById")]
        public object deleteAccGroupById(int id)
        {
            try
            {
                var accGrp = bMSContext.AccGroup.SingleOrDefault(u => u.Id == id);
                if (accGrp != null)
                {
                    bMSContext.AccGroup.Remove(accGrp);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = accGrp.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getAccGroupById")]
        public IEnumerable<AccGroup> getAccGroupById(int id)
        {
            return bMSContext.AccGroup.Where(u => u.Id == id).ToList();
        }

        [HttpGet]
        [Route("/api/getAllAccount")]
        public IEnumerable<Account> getAllAccount()
        {
            return bMSContext.Account.ToList();
        }

        [HttpGet]
        [Route("/api/getAllAccountFilterbased")]
        public IEnumerable<dynamic> getAllAccountFilterbased(string Name, int accNo, int groupId, int categoryId)
        {
            var result = (from acc in bMSContext.Account
                          join acgrp in bMSContext.AccGroup on acc.GroupId equals acgrp.Id
                          join accat in bMSContext.AccCategory on acc.AccountCategoryId equals accat.Id
                          where (groupId == 0 ||acc.GroupId==groupId)
                          where (categoryId==0 ||acc.GroupId==groupId)
                          where (accNo==0 ||acc.AccountNumber==accNo)
                          where (Name == "All" || acc.Name == Name)
                          select new
                          {
                              accCategoryId=acgrp.Name,
                              accGroupId=acgrp.Name,
                              accountNumber=acc.AccountNumber,
                              accountTypeId=accat.Name,
                              kindCode=acc.KindCode,
                              taxAmount=acc.TaxAmount,
                              taxLimit=acc.TaxLimit,
                              id=acc.Id,
                              name=acc.Name,
                              manualCode=acc.ManualCode,
                          }
                        ).ToList();
            //var query = bMSContext.Account.AsQueryable();
            //if (Name != "All")
            //{
            //    query = query.Where(i => i.Name.Contains(Name));
            //}

            //if (accNo != 0)
            //{
            //    query = query.Where(i => i.AccountNumber == accNo);
            //}
            //if (groupId > 0)
            //{
            //    query = query.Where(i => i.GroupId == groupId);
            //}

            //if (categoryId > 0)
            //{
            //    query = query.Where(i => i.AccountCategoryId == categoryId);
            //}


            return result;
        }

        [HttpGet]
        [Route("/api/getAllAccountGroupFilterbased")]
        public IEnumerable<AccGroup> getAllAccountGroupFilterbased(string Name, int accType, string manualCode, string priority)
        {
            var query = bMSContext.AccGroup.AsQueryable();
            if (Name != "All")
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            if (accType > 0)
            {
                query = query.Where(i => i.AccountTypeId == accType);
            }
            if (manualCode != "All")
            {
                query = query.Where(i => i.ManualCode.Contains(manualCode));
            }

            if (priority != "All")
            {
                query = query.Where(i => i.Priority.Contains(priority));
            }

            return query.ToList();
        }

        [HttpGet]
        [Route("/api/getAllAccountCategoryFilterbased")]
        public IEnumerable<AccCategory> getAllAccountCategoryFilterbased(string Name, int accType, string manualCode, string priority)
        {
            var query = bMSContext.AccCategory.AsQueryable();
            if (Name != "All")
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            if (accType > 0)
            {
                query = query.Where(i => i.AccountTypeId == accType);
            }
            if (manualCode != "All")
            {
                query = query.Where(i => i.ManualCode.Contains(manualCode));
            }

            if (priority != "All")
            {
                query = query.Where(i => i.Priority.Contains(priority));
            }

            return query.ToList();
        }

        [HttpPost]
        [Route("/api/createAccount")]
        public object createAccount(Account acc)
        {

            try
            {
                try
                {
                    var accChk = bMSContext.Account.SingleOrDefault(u => u.Id == acc.Id);
                    if (accChk != null)
                    {

                        accChk.Id = acc.Id;
                        accChk.AccountCategoryId = acc.AccountCategoryId;
                        accChk.AccountNumber = acc.AccountNumber;
                        accChk.AccountTypeId = acc.AccountTypeId;
                        accChk.SubCdTypeId = acc.SubCdTypeId;
                        accChk.SubGroupId = acc.SubGroupId;
                        accChk.GroupId = acc.GroupId;
                        accChk.BalanceLimit = acc.BalanceLimit;
                        accChk.DiscNo = acc.DiscNo;
                        accChk.Priority = acc.Priority;
                        accChk.TaxLimit = acc.TaxLimit;
                        accChk.Name = acc.Name;
                        accChk.Remarks = acc.Remarks;
                        accChk.TypeId = acc.TypeId;
                        accChk.TaxAmount = acc.TaxAmount;
                        accChk.ManualCode = acc.ManualCode;
                        accChk.KindCode = acc.KindCode;
                        accChk.UpdatedAt = DateTime.Now;
                        accChk.UpdatedBy = acc.UpdatedBy;
                        bMSContext.Account.Update(accChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accChk.Id });
                    }
                    else
                    {
                        var latestAccount = bMSContext.Account
                        .OrderByDescending(a => a.AccountNumber)
                        .FirstOrDefault();

                        long newAccountNumber = 1;

                        if (latestAccount != null)
                        {
                            newAccountNumber = latestAccount.AccountNumber + 1;
                        }
                        Account account = new Account(); 
                        account.AccountCategoryId = acc.AccountCategoryId;
                        account.AccountNumber = newAccountNumber;
                        account.AccountTypeId = acc.AccountTypeId;
                        account.SubCdTypeId = acc.SubCdTypeId;
                        account.SubGroupId = acc.SubGroupId;
                        account.GroupId = acc.GroupId;
                        account.BalanceLimit = acc.BalanceLimit;
                        account.DiscNo = acc.DiscNo;
                        account.Priority = acc.Priority;
                        account.TaxLimit = acc.TaxLimit;
                        account.Name = acc.Name;
                        account.Remarks = acc.Remarks;
                        account.TypeId = acc.TypeId;
                        account.TaxAmount = acc.TaxAmount;
                        account.ManualCode = acc.ManualCode;
                        account.KindCode = acc.KindCode;
                        account.CreatedAt = DateTime.Now;
                        account.CreatedBy = acc.CreatedBy;
                        bMSContext.Account.Add(account);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = account.Id });
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
        [Route("/api/deleteAccountById")]
        public object deleteAccountById(int id)
        {
            try
            {
                var acc = bMSContext.Account.SingleOrDefault(u => u.Id == id);
                if (acc != null)
                {
                    bMSContext.Account.Remove(acc);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = acc.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        [HttpGet]
        [Route("/api/getAccountById")]
        public IEnumerable<Account> getAccountById(int id)
        {
            return bMSContext.Account.Where(u => u.Id == id).ToList();
        }


    }
}
