using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterContentPanelController : Controller
    {
        // GET: WriterContentPanel
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult MyContent(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;     
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerIdInfo;
            p.ContentStatus = true;
            contentManager.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}