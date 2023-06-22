using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Context dbContext = new Context();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}