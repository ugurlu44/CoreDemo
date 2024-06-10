using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            List<Blog> blogList = bm.GetBlogListWithCategory();
            return View(blogList);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult Last3Blog()
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);

        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            //Blogun içindeki Dropdownlist'i doldurma
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                 ).ToList();
            ViewBag.cv = categoryvalues;
            return View();

        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                var usermail = User.Identity.Name;
                var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
                blog.WriterID = writerID;
                bm.Insert(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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
            return View(blog);
        }
        public IActionResult BlogDelete(int id)
        {
            var datavalue = bm.TGetById(id);
            datavalue.BlogStatus = false;
            bm.Update(datavalue);
            return RedirectToAction("BlogListByWriter");
        }


        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var datavalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                ).ToList();
            ViewBag.cv = categoryvalues;
            return View(datavalue);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID = writerID;
            blog.BlogStatus = true;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
