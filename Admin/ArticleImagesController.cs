using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmCooperation.Models;

namespace Admin
{
    public class ArticleImagesController : Controller
    {
        private readonly AdminContext _context;

        public ArticleImagesController(AdminContext context)
        {
            _context = context;
        }

        // GET: ArticleImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleImages.ToListAsync());
        }

        // GET: ArticleImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleImage = await _context.ArticleImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleImage == null)
            {
                return NotFound();
            }

            return View(articleImage);
        }

        // GET: ArticleImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl")] ArticleImage articleImage)
        {
            
                _context.Add(articleImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: ArticleImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleImage = await _context.ArticleImages.FindAsync(id);
            if (articleImage == null)
            {
                return NotFound();
            }
            return View(articleImage);
        }

        // POST: ArticleImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl")] ArticleImage articleImage)
        {
            if (id != articleImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleImageExists(articleImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articleImage);
        }

        // GET: ArticleImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleImage = await _context.ArticleImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleImage == null)
            {
                return NotFound();
            }

            return View(articleImage);
        }

        // POST: ArticleImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleImage = await _context.ArticleImages.FindAsync(id);
            if (articleImage != null)
            {
                _context.ArticleImages.Remove(articleImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleImageExists(int id)
        {
            return _context.ArticleImages.Any(e => e.Id == id);
        }
    }
}
