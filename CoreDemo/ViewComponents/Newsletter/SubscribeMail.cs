using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Newsletter
{
    public class SubscribeMail : ViewComponent
    {
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());
        //[HttpGet]
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}
        [HttpPost]
        public IViewComponentResult Invoke(EntityLayer.Concrete.Newsletter newsletter)
        {
            //newsletter.Mail = "test";
            //newsletter.MailStatus = true;
            nm.NewsletterAdd(newsletter);
            return View();
        }
    }
}
