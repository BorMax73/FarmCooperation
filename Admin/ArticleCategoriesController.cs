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
    public class ArticleCategoriesController : Controller
    {
        private readonly AdminContext _context;

        public ArticleCategoriesController(AdminContext context)
        {
            _context = context;
        }

        // GET: ArticleCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleCategories.ToListAsync());
        }

        // GET: ArticleCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleCategory = await _context.ArticleCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleCategory == null)
            {
                return NotFound();
            }

            return View(articleCategory);
        }

        // GET: ArticleCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ArticleCategory articleCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleCategory);
        }

        // GET: ArticleCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleCategory = await _context.ArticleCategories.FindAsync(id);
            if (articleCategory == null)
            {
                return NotFound();
            }
            return View(articleCategory);
        }

        // POST: ArticleCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ArticleCategory articleCategory)
        {
            if (id != articleCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleCategoryExists(articleCategory.Id))
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
            return View(articleCategory);
        }

        // GET: ArticleCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleCategory = await _context.ArticleCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleCategory == null)
            {
                return NotFound();
            }

            return View(articleCategory);
        }

        // POST: ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleCategory = await _context.ArticleCategories.FindAsync(id);
            if (articleCategory != null)
            {
                _context.ArticleCategories.Remove(articleCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleCategoryExists(int id)
        {
            return _context.ArticleCategories.Any(e => e.Id == id);
        }
    }
}
