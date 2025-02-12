using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectEcommerce.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager=new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());   
        public ActionResult WriterProfileIndex()
        {
            return View();
        }
        public ActionResult MyHeading() 
        {
            //id = 2;
            var values=headingManager.GetListByWriter();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading() 
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()

                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }
                                                ).ToList();
            ViewBag.bagCategory = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 4;
            p.HeadingStatus=true;
            headingManager.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateHeadingWP(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()

                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }
                                                ).ToList();
            ViewBag.bagCategory = valueCategory;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeadingWP(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeadingWP(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);

            return RedirectToAction("MyHeading");
        }
    }
}