using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            WriterManager wm = new WriterManager(new EfWriterRepository());
            var values = wm.GetWriterByID(2);
            return View(values);
        }
    }
}
