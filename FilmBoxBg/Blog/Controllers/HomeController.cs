using Blog.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List", "Article");
        }

        public ActionResult ListCategories()
        {
            using (var db = new BlogDbContext())
            {
                var categories = db.Categories
                    .Include(c => c.Articles)
                    .ToList();

                return View(categories);
            }
        }
    }
}