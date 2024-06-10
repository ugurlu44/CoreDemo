using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;

namespace CoreDemo.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,6);
            return View(values);
        }

        
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                cm.Insert(category);
                return RedirectToAction("Category", "Admin");
                //kaydedilmiştir.
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Kaydetme sırasında hata oluştu");

                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);            
            cm.Delete(value);
            return RedirectToAction("Category","Admin");
            
        }
    }
}
