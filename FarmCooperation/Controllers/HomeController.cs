using FarmCooperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FarmCooperation.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmCooperation.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            var articles = _context.Articles.Include(x => x.Image).Take(8).ToList();
            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
