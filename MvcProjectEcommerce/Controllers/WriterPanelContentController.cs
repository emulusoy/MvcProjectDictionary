using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectEcommerce.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();//maille giren kisinin idsini getirme
            var contentValues = contentManager.GetListByWriterId(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.IdValue = id;    
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mailValue = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mailValue).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerIdInfo;
            p.ContentStatus =true;
            contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}