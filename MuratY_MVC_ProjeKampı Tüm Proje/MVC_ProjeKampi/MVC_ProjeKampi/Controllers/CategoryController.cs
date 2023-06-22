using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            //var categoryValues = this.categoryManager.GetAllBL();
            //return View(categoryValues);

            var categoryValues = this.categoryManager.GetList();
            return View(categoryValues);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                this.categoryManager.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //this.categoryManager.CategoryAddBL(p);
            //return RedirectToAction("GetCategoryList");
            return View();
        }
    }
}