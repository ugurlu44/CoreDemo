using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
            Context c = new Context();
            var usermail=User.Identity.Name;
            var username = c.Writers.Where(x=>x.WriterMail==usermail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.Username = username;
            //WriterManager wm = new WriterManager(new EfWriterRepository());
            //var values = wm.GetList();
            return View();
        }
    }
}
