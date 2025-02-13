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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            Context context= new Context(); 
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();//maille giren kisinin idsini getirme
            var contentValues = contentManager.GetListByWriterId(writerIdInfo);
            return View(contentValues);
        }
    }
}