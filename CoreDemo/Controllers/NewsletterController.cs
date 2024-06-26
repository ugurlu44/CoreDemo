using BusinessLayer.Concrete;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var jsonNewsletter = JsonConvert.SerializeObject(p);
            return Json(jsonNewsletter);
        }

        //[HttpPost]
        //public IActionResult SubscribeMail(Newsletter p)
        //{
        //    p.MailStatus = true;
        //    nm.NewsletterAdd(p);
        //    return PartialView();
        //}
    }
}
