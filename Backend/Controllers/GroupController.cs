using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Backend.Model;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class GroupController : Controller
    {
        ERPContext bMSContext = new ERPContext();
        [HttpGet]
        [Route("/api/getAllGroup")]
        public IEnumerable<Group> getAllGroup()
        {
            return bMSContext.Group.ToList();
        }
        [HttpPost]
        [Route("/api/createGroup")]
        public object createGroup(Group user)
        {
            try
            {
                try
                {
                    var usrCheck = bMSContext.Group.SingleOrDefault(u => u.Id == user.Id);
                    if (usrCheck != null)
                    {
                        usrCheck.Id = user.Id;
                        usrCheck.Name = user.Name; 
                        usrCheck.UpdatedAt = DateTime.Now;
                        usrCheck.UpdatedBy = user.UpdatedBy;
                        bMSContext.Group.Update(usrCheck);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = usrCheck.Id });
                    }
                    else
                    {
                        Group usr = new Group();
                        usr.Id = user.Id;
                        usr.Name = user.Name;
                        usr.CreatedAt = DateTime.Now;
                        usr.CreatedBy = user.CreatedBy;
                        bMSContext.Group.Add(usr);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = usr.Id });
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
        [Route("/api/deleteGroupById")]
        public object deleteGroupById(long id)
        {
            try
            {
                var usr = bMSContext.Group.SingleOrDefault(u => u.Id == id);
                if (usr != null)
                {
                    bMSContext.Group.Remove(usr);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = usr.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;

        }
        [HttpGet]
        [Route("/api/getGroupById")]
        public IEnumerable<Group> getGroupById(long id)
        {
            return bMSContext.Group.Where(u => u.Id == id).ToList();
        }
    }
}
