using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectEcommerce.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetAllContent(string p="")
        {
            var values=contentManager.GetList(p);       
            return View(values.ToList());
            
           // var values=context.Contents.ToList();
            
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues=contentManager.GetListByHeadingId(id);

            return View(contentValues);
        }
    }
}