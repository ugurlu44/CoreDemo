using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            ViewBag.Usermail = usermail;
            var username = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.Username = username;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.WriterImage = c.Writers.Where(x => x.WriterID == writerID).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count();
            ViewBag.v2 = c.Blogs.Where(x=>x.WriterID == writerID).Count();
            ViewBag.v3 = c.Categories.Count();
            //var values = c.Writers.Where(x => x.WriterMail == usermail).ToList();
            return View();
        }
    }
}
