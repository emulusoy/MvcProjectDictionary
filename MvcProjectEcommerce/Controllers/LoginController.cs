using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjectEcommerce.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context value = new Context();
            var adminUser=value.Admins.FirstOrDefault(x=>x.AdminUsername==p.AdminUsername && x.AdminPassword==p.AdminPassword);
            if (adminUser != null) 
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUsername, false);
                Session["AdminUsername"]=adminUser.AdminUsername;
                return RedirectToAction("Index","AdminCategory");
            }
            else 
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}