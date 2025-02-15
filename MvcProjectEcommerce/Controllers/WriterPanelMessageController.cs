using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectEcommerce.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator valid = new MessageValidator();
        
        public ActionResult InboxWP()
        {
            string  p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInbox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenuWP()
        {
            return PartialView();
        }
        public ActionResult SendBoxWP()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendBox(p);
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetailsWP(int id)
        {

            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        public ActionResult GetSendBoxMessageDetailsWP(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        [HttpGet]
        public ActionResult NewMessageWP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessageWP(Message p)
        {
            string mailP = (string)Session["WriterMail"];
            ValidationResult results = valid.Validate(p);
            if (results.IsValid)
            {
                p.MessageSenderMail = mailP;
                ViewBag.mail= mailP;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);
                return RedirectToAction("SendBoxWP");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}