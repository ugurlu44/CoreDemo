using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    //ViewComponent sınıfından miras alması için biz ekliyoruz
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count;
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            string api = "14637100292b1a562410557f949bb6c8";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Diez&mode=xml&lang=tr&units=metric&appid="+api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v4=document.Descendants("temperature").FirstOrDefault().Attribute("value").Value.ElementAt(0);
            
            return View(); 
        }
    }
}
