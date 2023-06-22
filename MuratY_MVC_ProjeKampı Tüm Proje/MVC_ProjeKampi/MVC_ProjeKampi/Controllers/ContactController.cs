using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            var contactValues = this.contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = this.contactManager.GetByID(id);
            return View(contactValues); 
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}