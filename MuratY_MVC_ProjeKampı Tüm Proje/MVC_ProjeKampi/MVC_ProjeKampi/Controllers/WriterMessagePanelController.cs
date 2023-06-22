using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterMessagePanelController : Controller
    {
        // GET: WriterMessagePanel
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();


        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = this.messageManager.GetListInbox(p);   
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = this.messageManager.GetByID(id);
            return View(messageValues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValues = this.messageManager.GetByID(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                string sender = (string)Session["WriterMail"];
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAddBL(message);
                return RedirectToAction("Sendbox");
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