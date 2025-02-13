using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectEcommerce.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidation = new MessageValidator();
        public ActionResult InboxWP()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }
        public PartialViewResult MessageListMenuWP()
        {
            return PartialView();
        }
        public ActionResult SendBoxWP()
        {
            var messageList = messageManager.GetListSendBox();
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetailsWP(int id)
        {

            var messageValues = messageManager.GetById(id);

            return View(messageValues);
        }
        public ActionResult GetSendboxMessageDetailsWP(int id)
        {

            var messageValues = messageManager.GetById(id);

            return View(messageValues);
        }
        [HttpGet]
        public ActionResult AddMessageWP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessageWP(Message p)
        {
            ValidationResult results = messageValidation.Validate(p);
            if (results.IsValid)
            {
                p.MessageSenderMail = "mehmetkala@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);
                return RedirectToAction("SendBox");
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