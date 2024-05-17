using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 2;
            cm.Insert(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
