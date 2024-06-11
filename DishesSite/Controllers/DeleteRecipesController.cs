using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class DeleteRecipesController : Controller
    {
        private readonly DishesSiteContext _context;

        public DeleteRecipesController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Рецепты.ToListAsync();
            var viewModel = new List<DeleteRecipesViewModel>();

            foreach (var r in recipes)
            {
                viewModel.Add(new DeleteRecipesViewModel
                {
                    Рецепт_Id = r.Рецепт_Id,
                    Название_рецепта = r.Название_рецепта,
                    Описание = r.Описание,
                    Ингредиенты = r.Ингредиенты,
                    Инструкции = r.Инструкции
                });
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Рецепт_Id)
        {
            var recipe = await _context.Рецепты.FindAsync(Рецепт_Id);

            if (recipe == null)
            {
                return NotFound();
            }

            // Найти все записи в таблице Рейтинг, связанные с удаляемым рецептом
            var ratings = _context.Рейтинг.Where(r => r.Рецепт_Id == Рецепт_Id);

            // Удалить найденные записи из таблицы Рейтинг
            _context.Рейтинг.RemoveRange(ratings);

            // Удалить сам рецепт из таблицы Рецепты
            _context.Рецепты.Remove(recipe);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
