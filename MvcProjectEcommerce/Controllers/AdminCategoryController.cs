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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryValues = cm.GetById(id);
            cm.CategoryDelete(categoryValues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var categoryValues = cm.GetById(id);
            return View(categoryValues);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}