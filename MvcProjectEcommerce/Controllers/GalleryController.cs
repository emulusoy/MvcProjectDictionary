using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

namespace MvcProjectEcommerce.Controllers
{
    public class GalleryController : Controller
    {

        GalleryManager galleryManager=new GalleryManager(new EfGalleryDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var listImage=galleryManager.GetAllImages();
            return View(listImage);
        }
    }
}