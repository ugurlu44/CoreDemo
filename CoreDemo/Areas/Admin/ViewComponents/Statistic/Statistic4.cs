using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        { 
            ViewBag.v1 = adm.GetList().Where(x=>x.AdminID==1).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = adm.GetList().Where(x=>x.AdminID == 1).Select(x => x.ImageUrl).FirstOrDefault();
            var values = adm.GetAdminById(1);
            return View(values); 
        }
    }
}
