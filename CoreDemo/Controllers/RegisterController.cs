using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// F5 tamamen ilerle gidişat içinde break point varsa orda dur
        /// 5. satıra bir breakpoint koydum  -> durdu
        /// 6. satırda bir method vardı (35. satırda bu method tanımlı)
        /// 7. satırda bir şey yok
        /// 8. satırda bir şey yok
        /// 9. satırda bir şey yok
        /// 10. satırda bir şey yok
        /// 11. satırda breakpoint var...  duracak
        /// 
        /// 
        /// f10 yapıyor ... doğrudan sonra ki satıra geçiyor. Method olup olmaması önemsiz....
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "deneme test";
                writer.WriterImage = "test";
                wm.WriterAdd(writer);
                return RedirectToAction("Index","Blog");
                //kaydedilmiştir.
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
    }
}
