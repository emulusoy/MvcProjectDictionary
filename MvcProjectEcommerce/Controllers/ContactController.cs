using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;

namespace MvcProjectEcommerce.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager=new ContactManager(new EfContactDal());

        ContactValidator contactValidator=new ContactValidator();
        public ActionResult Index()
        {
            var contactList=contactManager.GetList();
            return View(contactList);
        }
        public ActionResult GetContactDetails(int id)
        {

            var contactValues=contactManager.GetById(id);

            return View(contactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}