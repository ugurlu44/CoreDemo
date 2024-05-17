using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var values = cm.GetList();
            return View(values);
        }
    }
}
