using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    //Bu seviyede Authorize eklersek, dışarıdan linkle hiçbir View'e erişim sağlanamaz.
    //Her View için tek tek tanımlamaya gerek kalmaz
    //[Authorize] //Startup içinde proje seviyesinde tanımladık.
    public class WriterController : Controller
    {
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }
        
        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
