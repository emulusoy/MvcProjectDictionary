using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using System.Web.Security;
using DataAccessLayer.Concrete;
using System.Web.Configuration;

namespace MvcProjectEcommerce.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        // GET: WriterLogin
        
            [HttpGet]
            public ActionResult WriterLogin()
            {
                return View();
            }
            [HttpPost]
            public ActionResult WriterLogin(Writer p)
            {
                Context value2 = new Context();
                var writerUser = value2.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
                if (writerUser != null)
                {
                    FormsAuthentication.SetAuthCookie(writerUser.WriterMail, false);
                    Session["WriterMail"] = writerUser.WriterMail;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    return RedirectToAction("WriterLogin");
                }
        }
        
    }
}
//< customErrors mode = "On" >

//          < error statusCode = "404" redirect = "/ErrorPage/Page404/" />

//          < error statusCode = "401" redirect = "/ErrorPage/Page401/" />

//      </ customErrors >

//      < authentication mode = "Forms" >

//          < forms loginUrl = "/ErrorPage/Page401/" ></ forms >

//      </ authentication >