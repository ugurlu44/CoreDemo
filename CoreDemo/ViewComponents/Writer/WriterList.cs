using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            WriterManager wm = new WriterManager(new EfWriterRepository());
            var values = wm.GetList();
            return View(values);
        }
    }
}
