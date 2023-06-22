using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        
        public ActionResult Headings()
        {
            var headingList = this.headingManager.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id = 1)
        {
            var contentList = this.contentManager.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}