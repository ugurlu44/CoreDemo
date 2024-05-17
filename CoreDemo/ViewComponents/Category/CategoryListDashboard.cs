using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
