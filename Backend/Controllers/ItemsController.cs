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
    public class ItemsController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        #region Brand
        [HttpGet]
        [Route("/api/getAllBrands")]
        public IEnumerable<ItemBrand> getAllBrands()
        {
            return bMSContext.ItemBrand.ToList();
        }

        [HttpPost]
        [Route("/api/createBrands")]
        public object createBrands(ItemBrand brand)
        {

            try
            {
                try
                {
                    var brandchk = bMSContext.ItemBrand.SingleOrDefault(u => u.Id == brand.Id);
                    if (brandchk != null)
                    {

                        brandchk.Id = brand.Id;
                        brandchk.Name = brand.Name;
                        brand.UpdatedAt = DateTime.Now;
                        brandchk.UpdatedBy = brand.UpdatedBy;
                        bMSContext.ItemBrand.Update(brandchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = brandchk.Id });
                    }
                    else
                    {
                        ItemBrand brand1 = new ItemBrand();
                        //brandchk.Id = brand.Id;
                        brand1.Name = brand.Name;
                        brand1.CreatedAt = DateTime.Now;
                        brand1.CreatedBy = brand.CreatedBy;
                        bMSContext.ItemBrand.Add(brand1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = brand1.Id });
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
        [Route("/api/deleteBrandById")]
        public object deleteBrandById(int id)
        {
            try
            {
                var delbrand = bMSContext.ItemBrand.SingleOrDefault(u => u.Id == id);
                if (delbrand != null)
                {
                    bMSContext.ItemBrand.Remove(delbrand);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delbrand.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getBrandById")]
        public IEnumerable<ItemBrand> getBrandById(int id)
        {
            return bMSContext.ItemBrand.Where(u => u.Id == id).ToList();
        }
        #endregion

        #region Category

        [HttpGet]
        [Route("/api/getAllCategory")]
        public IEnumerable<ItemCategory> getAllCategory()
        {
            return bMSContext.ItemCategory.ToList();
        }

        [HttpPost]
        [Route("/api/createCategory")]
        public object createCategory(ItemCategory itemCategory)
        {

            try
            {
                try
                {
                    var categorychk = bMSContext.ItemCategory.SingleOrDefault(u => u.Id == itemCategory.Id);
                    if (categorychk != null)
                    {

                        categorychk.Id = itemCategory.Id;
                        categorychk.Name = itemCategory.Name;
                        categorychk.IsActive = itemCategory.IsActive;
                        categorychk.Priority = itemCategory.Priority;
                        categorychk.DepartmentId = itemCategory.DepartmentId;
                        categorychk.Height = itemCategory.Height;
                        categorychk.Width = itemCategory.Width;
                        categorychk.Description = itemCategory.Description;
                        categorychk.UpdatedAt = DateTime.Now;
                        categorychk.UpdatedBy = itemCategory.UpdatedBy;
                        bMSContext.ItemCategory.Update(categorychk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = categorychk.Id });
                    }
                    else
                    {
                        ItemCategory itemCategory1 = new ItemCategory();
                        //brandchk.Id = brand.Id;
                        itemCategory1.Name = itemCategory.Name;
                        itemCategory1.IsActive = itemCategory.IsActive;
                        itemCategory1.Priority = itemCategory.Priority;
                        itemCategory1.DepartmentId = itemCategory.DepartmentId;
                        itemCategory1.Height = itemCategory.Height;
                        itemCategory1.Width = itemCategory.Width;
                        itemCategory1.Description = itemCategory.Description;
                        itemCategory1.CreatedAt = DateTime.Now;
                        itemCategory1.CreatedBy = itemCategory.CreatedBy;
                        bMSContext.ItemCategory.Add(itemCategory1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemCategory1.Id });
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
        [Route("/api/deleteCategoryById")]
        public object deleteCatgoryById(int id)
        {
            try
            {
                var delcategory = bMSContext.ItemCategory.SingleOrDefault(u => u.Id == id);
                if (delcategory != null)
                {
                    bMSContext.ItemCategory.Remove(delcategory);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delcategory.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getCategoryById")]
        public IEnumerable<ItemCategory> getCategoryById(int id)
        {
            return bMSContext.ItemCategory.Where(u => u.Id == id).ToList();
        }

        #endregion

        #region Class

        [HttpGet]
        [Route("/api/getAllClass")]
        public IEnumerable<ItemClass> getAllClass()
        {
            return bMSContext.ItemClass.ToList();
        }

        [HttpPost]
        [Route("/api/createClass")]
        public object createClass(ItemClass itemClass)
        {

            try
            {
                try
                {
                    var classchk = bMSContext.ItemClass.SingleOrDefault(u => u.Id == itemClass.Id);
                    if (classchk != null)
                    {

                        classchk.Id = itemClass.Id;
                        classchk.Name = itemClass.Name;
                        classchk.DepartmentId = itemClass.DepartmentId;
                        classchk.CategoryId = itemClass.CategoryId;
                        classchk.UpdatedAt = DateTime.Now;
                        classchk.UpdatedBy = itemClass.UpdatedBy;
                        bMSContext.ItemClass.Update(classchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = classchk.Id });
                    }
                    else
                    {
                        ItemClass itemClass1 = new ItemClass();

                        itemClass1.Name = itemClass.Name;
                        itemClass1.DepartmentId = itemClass.DepartmentId;
                        itemClass1.CategoryId = itemClass.CategoryId;
                        itemClass1.CreatedAt = DateTime.Now;
                        itemClass1.CreatedBy = itemClass.CreatedBy;
                        bMSContext.ItemClass.Add(itemClass1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemClass1.Id });
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
        [Route("/api/deleteClassById")]
        public object deleteClassById(int id)
        {
            try
            {
                var delclass = bMSContext.ItemClass.SingleOrDefault(u => u.Id == id);
                if (delclass != null)
                {
                    bMSContext.ItemClass.Remove(delclass);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delclass.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getClassById")]
        public IEnumerable<ItemClass> getClassById(int id)
        {
            return bMSContext.ItemClass.Where(u => u.Id == id).ToList();
        }
        #endregion

        #region Item

        [HttpGet]
        [Route("/api/getAllItems")]
        public IEnumerable<Item> getAllItems()
        {
            return bMSContext.Item.ToList();
        }


        [HttpGet]
        [Route("/api/getAllItemsdetailsFilterbased")]
        public IEnumerable<Item> getAllItemsdetailsFilterbased(string itemName, string aliasName, decimal purchasePrice, decimal salePrice)
        {
            var query = bMSContext.Item.AsQueryable(); 
            if (itemName != "All")
            {
                query = query.Where(i => i.ItemName.Contains(itemName));
            }

            if (aliasName != "All")
            {
                query = query.Where(i => i.AliasName.Contains(aliasName));
            } 
            if (purchasePrice > 0)
            {
                query = query.Where(i => i.PurchasePrice == purchasePrice);
            }

            if (salePrice > 0)
            {
                query = query.Where(i => i.SalePrice == salePrice);
            }

            return query.ToList();
        }


        [HttpPost]
        [Route("/api/createItems")]
        public object createItems(Item Items)
        {

            try
            {
                try
                {
                    var Itemschk = bMSContext.Item.SingleOrDefault(u => u.Id == Items.Id);
                    if (Itemschk != null)
                    {

                        Itemschk.Id = Items.Id;
                        Itemschk.AliasName = Items.AliasName;
                        Itemschk.ItemName = Items.ItemName;
                        Itemschk.PurchasePrice = Items.PurchasePrice;
                        Itemschk.SalePrice = Items.SalePrice;
                        Itemschk.CategoryId = Items.CategoryId;
                        Itemschk.ClassId = Items.ClassId;
                        Itemschk.ManufacturerId = Items.ManufacturerId;
                        Itemschk.Remarks = Items.Remarks;
                        Itemschk.RecentPurchase = Items.RecentPurchase;
                        Itemschk.BrandId = Items.BrandId;
                        Itemschk.Discflat = Items.Discflat;
                        Itemschk.Lockdisc = Items.Lockdisc;
                        Itemschk.UpdatedAt = DateTime.Now;
                        Itemschk.UpdatedBy = Items.UpdatedBy;
                        bMSContext.Item.Update(Itemschk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = Itemschk.Id });
                    }
                    else
                    {
                        Item itemItems = new Item();

                        itemItems.AliasName = Items.AliasName;
                        itemItems.ItemName = Items.ItemName;
                        itemItems.PurchasePrice = Items.PurchasePrice;
                        itemItems.SalePrice = Items.SalePrice;
                        itemItems.CategoryId = Items.CategoryId;
                        itemItems.ClassId = Items.ClassId;
                        itemItems.ManufacturerId = Items.ManufacturerId;
                        itemItems.Remarks = Items.Remarks;
                        itemItems.RecentPurchase = Items.RecentPurchase;
                        itemItems.BrandId = Items.BrandId;
                        itemItems.Discflat = Items.Discflat;
                        itemItems.Lockdisc = Items.Lockdisc;
                        itemItems.CreatedAt = DateTime.Now;
                        itemItems.CreatedBy = Items.CreatedBy;
                        bMSContext.Item.Add(itemItems);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemItems.Id });
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
        [Route("/api/deleteItemById")]
        public object deleteItemById(int id)
        {
            try
            {
                var delitem = bMSContext.Item.SingleOrDefault(u => u.Id == id);
                if (delitem != null)
                {
                    bMSContext.Item.Remove(delitem);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delitem.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getItemById")]
        public IEnumerable<Item> getItemById(int id)
        {
            return bMSContext.Item.Where(u => u.Id == id).ToList();
        }
        #endregion

        #region Manufacturer

        [HttpGet]
        [Route("/api/getAllManufacturer")]
        public IEnumerable<ItemManufacturer> getAllManufacturer()
        {
            return bMSContext.ItemManufacturer.ToList();
        }

        [HttpPost]
        [Route("/api/createManufacturer")]
        public object createManufacturer(ItemManufacturer itemManufacturer)
        {

            try
            {
                try
                {
                    var Manufacturerchk = bMSContext.ItemManufacturer.SingleOrDefault(u => u.Id == itemManufacturer.Id);
                    if (Manufacturerchk != null)
                    {

                        Manufacturerchk.Id = itemManufacturer.Id;
                        Manufacturerchk.Name = itemManufacturer.Name;
                        Manufacturerchk.Telephoneno = itemManufacturer.Telephoneno;
                        Manufacturerchk.Telephoneno2 = itemManufacturer.Telephoneno2;
                        Manufacturerchk.Email = itemManufacturer.Email;
                        Manufacturerchk.Address = itemManufacturer.Address;
                        Manufacturerchk.UpdatedAt = DateTime.Now;
                        Manufacturerchk.UpdatedBy = itemManufacturer.UpdatedBy;
                        bMSContext.ItemManufacturer.Update(Manufacturerchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = Manufacturerchk.Id });
                    }
                    else
                    {
                        ItemManufacturer itemManufacturer1 = new ItemManufacturer();

                        itemManufacturer1.Name = itemManufacturer.Name;
                        itemManufacturer1.Telephoneno = itemManufacturer.Telephoneno;
                        itemManufacturer1.Telephoneno2 = itemManufacturer.Telephoneno2;
                        itemManufacturer1.Email = itemManufacturer.Email;
                        itemManufacturer.Address = itemManufacturer.Address;
                        itemManufacturer.CreatedAt = DateTime.Now;
                        itemManufacturer.CreatedBy = itemManufacturer.CreatedBy;
                        bMSContext.ItemManufacturer.Add(itemManufacturer1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemManufacturer1.Id });
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
        [Route("/api/deleteManufacturerById")]
        public object deleteManufacturerById(int id)
        {
            try
            {
                var delmanufacturer = bMSContext.ItemManufacturer.SingleOrDefault(u => u.Id == id);
                if (delmanufacturer != null)
                {
                    bMSContext.ItemManufacturer.Remove(delmanufacturer);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delmanufacturer.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getManufacturerById")]
        public IEnumerable<ItemManufacturer> getManufacturerById(int id)
        {
            return bMSContext.ItemManufacturer.Where(u => u.Id == id).ToList();
        }
        #endregion

        [HttpGet]
        [Route("/api/getDepartment")]
        public IEnumerable<Department> getDepartment()
        {
            return bMSContext.Department.ToList();
        }

        [HttpGet]
        [Route("/api/getActive")]
        public IEnumerable<Active> getActive()
        {
            return bMSContext.Active.ToList();
        }
    }
}
