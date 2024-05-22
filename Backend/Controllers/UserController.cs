using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Backend.Model;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class UserController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllUser")]
        public IEnumerable<User> getAllUser()
        {
            return bMSContext.User.ToList();
        }
        [HttpPost]
        [Route("/api/createUser")]
        public object createUser(User user)
        {
            try
            {
                try
                {
                    var usrCheck = bMSContext.User.SingleOrDefault(u => u.UserId == user.UserId);
                    if (usrCheck != null)
                    {
                        usrCheck.UserId = user.UserId;
                        usrCheck.Name = user.Name;
                        usrCheck.UserTypeId = user.UserTypeId;
                        usrCheck.Password = user.Password;
                        usrCheck.Email = user.Email;
                        usrCheck.Phone = user.Phone;
                        usrCheck.Address = user.Address;
                        usrCheck.Gender = user.Gender;
                        usrCheck.IsActive = user.IsActive;
                        usrCheck.JoiningDate = user.JoiningDate;
                        bMSContext.User.Update(usrCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = usrCheck.UserId });
                    }
                    else
                    {
                        User usr = new User();
                        usr.UserId = user.UserId;
                        usr.Name = user.Name;
                        usr.UserTypeId = user.UserTypeId;
                        usr.Password = user.Password;
                        usr.Email = user.Email;
                        usr.Phone = user.Phone;
                        usr.Address = user.Address;
                        usr.Gender = user.Gender;
                        usr.IsActive = user.IsActive;
                        usr.JoiningDate = user.JoiningDate;
                        bMSContext.User.Add(usr);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = usr.UserId });
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
        [HttpPost]
        [Route("/api/updateUser")]
        public string updateUser(User user)
        {
            try
            {
                var usrCheck = bMSContext.User.SingleOrDefault(u => u.UserId == user.UserId);
                usrCheck.UserId = user.UserId;
                usrCheck.Name = user.Name;
                usrCheck.UserTypeId = user.UserTypeId;
                usrCheck.Password = user.Password;
                usrCheck.Email = user.Email;
                usrCheck.Phone = user.Phone;
                usrCheck.Address = user.Address;
                usrCheck.Gender = user.Gender;
                usrCheck.IsActive = user.IsActive;
                usrCheck.JoiningDate = user.JoiningDate;
                bMSContext.User.Update(usrCheck);
                bMSContext.SaveChanges();
                return JsonConvert.SerializeObject(new { id = usrCheck.UserId });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("/api/deleteUserById")]
        public object deleteUserById(long id)
        {
            try
            {
                var usr = bMSContext.User.SingleOrDefault(u => u.UserId == id);
                if (usr != null)
                {
                    bMSContext.User.Remove(usr);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = usr.UserId });
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;

        }
        [HttpGet]
        [Route("/api/getUserById")]
        public IEnumerable<User> GetUserbyId(long id)
        {
            return bMSContext.User.Where(u => u.UserId == id).ToList();
        }
        [HttpGet]
        [Route("/api/getAllUserType")]
        public IEnumerable<UserType> getAllUserType()
        {
            return bMSContext.UserType.ToList();
        }
        [HttpPost]
        [Route("/api/Login")]
        public object Login(LoginModel loginModel)
        {
            try
            {
                var loginDtl = bMSContext.User.Where(u => u.Name.Contains(loginModel.Email) && u.Password == loginModel.Password).FirstOrDefault();
                if (loginDtl != null)
                {
                    if (loginDtl.Name != loginModel.Email)
                        return JsonConvert.SerializeObject(new { msg = "Invalid Name" });
                    if (loginDtl.Password != loginModel.Password)
                        return JsonConvert.SerializeObject(new { msg = "Invalid Password" });

                    return JsonConvert.SerializeObject(new { userType = loginDtl.UserTypeId });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { msg = "Invalid Login Credentials" });
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}