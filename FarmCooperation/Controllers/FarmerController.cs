using FarmCooperation.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmCooperation.Controllers
{
    public class FarmerController : Controller
    {
        private ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: FarmerController
        public ActionResult Index()
        {
            var farmers = _context.Farmers.ToList();
            if (farmers == null) 
                return NotFound();
            return View(farmers);
        }

        public ActionResult Details(int id)
        {
            var farmer = _context.Farmers.Find(id);
            if (farmer == null)
                return NotFound();
            return View(farmer);
        }

        
    }
}
