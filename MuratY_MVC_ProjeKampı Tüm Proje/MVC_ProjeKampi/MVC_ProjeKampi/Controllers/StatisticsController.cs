using Microsoft.Ajax.Utilities;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DataAccessLayer.Concrete.Context context = new DataAccessLayer.Concrete.Context();
        public ActionResult Index()
        {
            ViewBag.CategoryCounter = this.CategoryCounter();
            ViewBag.HeadingsOfYazılım = this.HeadingsOfYazılım();
            ViewBag.WritersOfContainsA = this.WritersOfContainsA();
            ViewBag.MaxHeadingsOfCategory = this.MaxHeadingsNumberOfCategory();
            ViewBag.StatusTrueOfCategory = this.StatusTrueOfCategories();

            return View();
        }

        public object CategoryCounter()
        {
            return this.context.Categories.Count().ToString();
        }

        public object HeadingsOfYazılım()
        {
            int count = 0;
            foreach (var heading in this.context.Headings)
            {
                if (heading.CategoryID == 21)
                {
                    count++;
                }
            }

            return count.ToString();

            //this.context.Headings.Count(c => c.CategoryID == 21).ToString();
        }

        public object WritersOfContainsA()
        {
            return this.context.Writers.Count(w => w.WriterName.Contains("a") || w.WriterName.Contains("A")).ToString();
        }

        public object MaxHeadingsNumberOfCategory()
        {
            return this.context.Categories.Where(
                c => c.CategoryID == this.context.Headings.GroupBy(
                    h => h.CategoryID).OrderByDescending(
                    o => o.Count()).Select(s => s.Key).FirstOrDefault()).Select(
                    s => s.CategryName).FirstOrDefault();
        }

        public object StatusTrueOfCategories()
        {
            return (this.context.Categories.Count(c => c.CategoryStatus == true) - 
                context.Categories.Count(c => c.CategoryStatus == false)).ToString();
        }
    }
}