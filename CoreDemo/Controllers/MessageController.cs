using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            int id = 3;
            var values = mm.GetInboxListByWriter(id);
            //ViewBag.messageCount = mm.GetInboxListByWriter(id).Count();
            return View(values);
        }

        
        public IActionResult MessageDetails(int id)
        {
            var values = mm.TGetById(id);            
            return View(values);
        }
    }
}
