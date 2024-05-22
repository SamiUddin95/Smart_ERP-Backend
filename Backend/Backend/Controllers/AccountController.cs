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
        public IEnumerable<AccCategory> getAllAccountCategory()
        {
            return bMSContext.AccCategory.ToList();
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
                        accCatChk.ManualCode = accCategory.ManualCode;
                        accCatChk.Priority = accCategory.Priority;
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
                        bMSContext.AccType.Update(accTypeChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accTypeChk.Id });
                    }
                    else
                    {
                        AccType accountType = new AccType();
                        accountType.Id = accType.Id;
                        accountType.Name = accType.Name;
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
        public IEnumerable<AccGroupCategory> getAllAccGroupCategory()
        {
            return bMSContext.AccGroupCategory.ToList();
        }
        [HttpPost]
        [Route("/api/createAccGroupCategory")]
        public object createAccGroupCategory(AccGroupCategory accGrpCat)
        {

            try
            {
                try
                {
                    var accGrpCatChk = bMSContext.AccGroupCategory.SingleOrDefault(u => u.Id == accGrpCat.Id);
                    if (accGrpCatChk != null)
                    {

                        accGrpCatChk.Id = accGrpCat.Id; 
                        accGrpCatChk.Name = accGrpCat.Name;
                        bMSContext.AccGroupCategory.Update(accGrpCatChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accGrpCatChk.Id });
                    }
                    else
                    {
                        AccGroupCategory accountGrpCat = new AccGroupCategory();
                        accountGrpCat.Id = accGrpCat.Id;
                        accountGrpCat.Name = accGrpCat.Name;
                        bMSContext.AccGroupCategory.Add(accountGrpCat);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accountGrpCat.Id });
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
        [Route("/api/deleteAccGroupCategoryById")]
        public object deleteAccGroupCategoryById(int id)
        {
            try
            {
                var accGrpCat = bMSContext.AccGroupCategory.SingleOrDefault(u => u.Id == id);
                if (accGrpCat != null)
                {
                    bMSContext.AccGroupCategory.Remove(accGrpCat);
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
        public IEnumerable<AccGroupCategory> getAccGroupCategoryById(int id)
        {
            return bMSContext.AccGroupCategory.Where(u => u.Id == id).ToList();
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
                        accGrpChk.GroupCategoryId = accGrp.GroupCategoryId;
                        accGrpChk.ManualCode = accGrp.ManualCode;
                        accGrpChk.Priority = accGrp.Priority;
                        bMSContext.AccGroup.Update(accGrpChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accGrpChk.Id });
                    }
                    else
                    {
                        AccGroup accountGrp = new AccGroup();
                        accountGrp.Id = accGrp.Id;
                        accountGrp.AccountTypeId = accGrp.AccountTypeId;
                        accountGrp.GroupCategoryId = accGrp.GroupCategoryId;
                        accountGrp.ManualCode = accGrp.ManualCode;
                        accountGrp.Priority = accGrp.Priority;
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
                        accChk.TaxLimit = acc.TaxLimit;
                        accChk.Name = acc.Name;
                        accChk.TypeId = acc.TypeId;
                        accChk.TaxAmount = acc.TaxAmount;
                        accChk.ManualCode = acc.ManualCode;
                        accChk.KindCode = acc.KindCode;
                        accChk.CreatedBy = acc.CreatedBy;
                        accChk.UpdatedBy = acc.UpdatedBy;
                        accChk.CreatedAt = acc.CreatedAt;
                        accChk.UpdatedAt = acc.UpdatedAt;
                        bMSContext.Account.Update(accChk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = accChk.Id });
                    }
                    else
                    {
                        Account account = new Account(); 
                        account.AccountCategoryId = acc.AccountCategoryId;
                        account.AccountNumber = acc.AccountNumber;
                        account.AccountTypeId = acc.AccountTypeId;
                        account.SubCdTypeId = acc.SubCdTypeId;
                        account.SubGroupId = acc.SubGroupId;
                        account.GroupId = acc.GroupId;
                        account.BalanceLimit = acc.BalanceLimit;
                        account.DiscNo = acc.DiscNo;
                        account.TaxLimit = acc.TaxLimit;
                        account.Name = acc.Name;
                        account.TypeId = acc.TypeId;
                        account.TaxAmount = acc.TaxAmount;
                        account.ManualCode = acc.ManualCode;
                        account.KindCode = acc.KindCode;
                        account.CreatedBy = acc.CreatedBy;
                        account.UpdatedBy = acc.UpdatedBy;
                        account.CreatedAt = acc.CreatedAt;
                        account.UpdatedAt = acc.UpdatedAt;
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
