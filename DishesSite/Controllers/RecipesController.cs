using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.Models;

namespace DishesSite.Controllers
{
    public class RecipesController : Controller
    {
        private readonly DishesSiteContext _context;

        public RecipesController(DishesSiteContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Рецепты.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Рецепты
                .FirstOrDefaultAsync(m => m.Рецепт_Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Рецепты
                .FirstOrDefaultAsync(m => m.Рецепт_Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Рецепты.FindAsync(id);
            if (recipe != null)
            {
                _context.Рецепты.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Рецепты.Any(e => e.Рецепт_Id == id);
        }
    }
}
