using System.Security.Claims;
using FarmCooperation.Data;
using FarmCooperation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FarmCooperation.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CartController
        [Authorize]
        public ActionResult Index()
        {
            var cart = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Article).ThenInclude(x => x.Image)
                .FirstOrDefault(x => x.ClientId == User.FindFirstValue(ClaimTypes.NameIdentifier) & x.Status == "cart");
            if (cart == null)
            {
                 _context.Orders.Add(new Order { ClientId = User.FindFirstValue(ClaimTypes.NameIdentifier), Status = "cart"});
                 _context.SaveChanges();
                 cart = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Article)
                        .FirstOrDefault(x => x.ClientId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return View(cart);
        }
        [Authorize]
        public ActionResult AddToCart(int id, int quantity)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
                return NotFound();
            var cart = _context.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.ClientId == User.FindFirstValue(ClaimTypes.NameIdentifier) & x.Status == "cart");
            if (cart == null)
            {
                cart = new Order { ClientId = User.FindFirstValue(ClaimTypes.NameIdentifier), Status = "cart"};
                _context.Orders.Add(cart);
            }
            _context.SaveChanges();
            var orderItem = _context.OrderItems.FirstOrDefault(x => x.ArticleId == id && x.OrderId == cart.Id);
            if (orderItem == null)
            {
                orderItem = new OrderItem { ArticleId = id, Quantity = quantity, OrderId = cart.Id };
                _context.OrderItems.Add(orderItem);
            }
            else
            {
                orderItem.Quantity += quantity;
                _context.OrderItems.Update(orderItem);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(x=>x.ArticleId == id);
            if (orderItem == null)
                return NotFound();
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Checkout()
        {
            var cart = _context.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.ClientId == User.FindFirstValue(ClaimTypes.NameIdentifier) & x.Status == "cart");
            if (cart == null)
                return NotFound();
            cart.Status = "Pending";
            _context.Orders.Update(cart);
            _context.SaveChanges();
            _context.Orders.Add(new Order { ClientId = User.FindFirstValue(ClaimTypes.NameIdentifier) , Status = "cart" });
            _context.SaveChanges();
            return View();
        }
    }
}
