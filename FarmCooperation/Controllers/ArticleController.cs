using FarmCooperation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmCooperation.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articles = _context.Articles.Include(x => x.Image).ToList();
            return View(articles);
        }
        [Route("Article/Category")]
        public IActionResult Index(int id)
        {
            var articles = _context.Articles.Include(x => x.Image).Where(x=>x.CategoryId == id).ToList();
            return View(articles);
        }
        [Route("Article/Details")]
        public IActionResult Details(int id)
        {
            var article = _context.Articles.Include(x=>x.Farmer).Include(x=>x.Image).FirstOrDefault(x=>x.Id == id);
            if (article == null)
                return NotFound();
            return View(article);
        }

    }
}
