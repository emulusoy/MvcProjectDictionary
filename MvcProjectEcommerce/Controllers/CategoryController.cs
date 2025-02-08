using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjectEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            var listCategory = cm.GetAllBL();
            return View(listCategory);
        }
        [HttpGet]
        ActionResult AddVategory(Category p)
        {
            return View(p);
        }
        [HttpPost]

    }
}