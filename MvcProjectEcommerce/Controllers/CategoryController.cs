using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;


namespace MvcProjectEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            var listCategory = cm.GetList();
            return View(listCategory);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.AddCategoryBL(p);
            
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results=categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("CategoryList");
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