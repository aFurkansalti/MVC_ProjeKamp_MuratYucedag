using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MVC_ProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal()); 
        WriterValidator writerValidator = new WriterValidator();
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 1)
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p;
            id = this.context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = this.writerManager.GetByID(id);
            ViewBag.a = id;
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = this.writerValidator.Validate(writer);
            if (results.IsValid)
            {
                this.writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel"); 
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

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = this.context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;
            return View();
        }
        
        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string writerMail = (string)Session["WriterMail"];
            var writerIdInfo = this.context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
            h.WriterID = writerIdInfo;
            h.HeadingStatus = true;
            headingManager.HeadingAddBL(h);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;
            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }


        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }

            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        [AllowAnonymous]
        public ActionResult AllHeading(int p = 1)
        {
            var headings = headingManager.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}