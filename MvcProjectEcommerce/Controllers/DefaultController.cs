using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectEcommerce.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager=new HeadingManager(new EfHeadingDal());
        ContentManager contentManager=new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var listHeading = headingManager.GetList();
            return View(listHeading);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList=contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}