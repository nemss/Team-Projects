using Blog.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class TagController : Controller
    {
        [HttpGet]
        public ActionResult ListArticlesByTag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var articles = db.Tags
                    .Include(t => t.Articles.Select(a => a.Author))
                    .Include(t => t.Articles.Select(a => a.Tags))
                    .FirstOrDefault(t => t.Id == id)
                    .Articles
                    .ToList();

                return View(articles);
            }
        }
    }
}