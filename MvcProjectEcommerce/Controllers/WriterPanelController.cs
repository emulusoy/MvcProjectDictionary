using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
namespace MvcProjectEcommerce.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager=new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());

        Context context = new Context();

        public ActionResult WriterProfileIndex()
        {
            return View();
        }
        public ActionResult MyHeading(string p) 
        {
            p = (string)Session["WriterMail"];
            var findWriterId = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values=headingManager.GetListByWriter(findWriterId);
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
            string mail = (string)Session["WriterMail"];
            var findWriterId = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = findWriterId;
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
        public ActionResult AllHeading(int page=1)//sayfalama islemi icin!
        {
            var headingsAll = headingManager.GetList().ToPagedList(page, 4);
            return View(headingsAll);
        }
    }
}