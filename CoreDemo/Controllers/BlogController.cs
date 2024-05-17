using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

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
            var values = bm.GetListWithCategoryByWriterBm(1);
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
                blog.WriterID = 1;
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
            blog.WriterID = 1;
            blog.BlogStatus = true;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
