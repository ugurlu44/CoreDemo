using BusinessLayer.Concrete;
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace CoreDemo.Areas.Admin.Views.Category
{
    [Authorize]
    [AllowAnonymous]
    [Area("Admin")]
    public class BlogController : Controller
    {
        
        public IActionResult ExportExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList2())
                {
                    worksheet.Cell(BlogRowCount,1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount,2).Value = item.BlogTitle;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            //return View();
        }
        //Manuel oluşturduğumuz listeden veri çekmek için
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1, BlogName="C# Programlamaya giriş"},
                new BlogModel{ID=2, BlogName="MVC.net Core Proje Kampı" },
                new BlogModel{ID=3, BlogName="2024 Olimpiyatları"}
            };
            return bm;
        }
        public List<Blog> GetBlogList2()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            List<Blog> values = bm.GetList();
            return values;
        }
        public IActionResult BlogListExcel()
        { 
            return View();
        }
    }
}
