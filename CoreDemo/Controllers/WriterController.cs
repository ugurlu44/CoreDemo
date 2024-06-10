using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    //Bu seviyede Authorize eklersek, dışarıdan linkle hiçbir View'e erişim sağlanamaz.
    //Her View için tek tek tanımlamaya gerek kalmaz
    //[Authorize] //Startup içinde proje seviyesinde tanımladık.
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        //[AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.Usermail = usermail;            
            var username = c.Writers.Where(x=>x.WriterMail==usermail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.Username = username;
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

        
        [HttpGet]
        public IActionResult WriterEditProfil() 
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x=>x.WriterMail==usermail).Select(y=> y.WriterID).FirstOrDefault();
            var values = wm.TGetById(writerID);
            return View(values);
        }
        
        [HttpPost]
        public IActionResult WriterEditProfil(Writer writer) 
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterID = 1;
                writer.WriterStatus = true;
                writer.WriterImage = "/writer/assets/images/faces/face2.jpg";
                wm.Update(writer);
                return RedirectToAction("WriterEditProfil");
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Kaydetme sırasında hata oluştu");

                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(writer);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null) 
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location,FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail=p.WriterMail;
            w.WriterName=p.WriterName;
            w.WriterPassword=p.WriterPassword;
            w.WriterStatus=true;
            w.WriterAbout=p.WriterAbout;

            wm.Insert(w);
            return RedirectToAction("Index","Dashboard");
        }
    }
}
