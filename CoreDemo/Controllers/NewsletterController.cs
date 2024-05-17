using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());
        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(Newsletter p)
        {
            p.MailStatus = true;
            nm.NewsletterAdd(p);
            return PartialView();
        }
    }
}
