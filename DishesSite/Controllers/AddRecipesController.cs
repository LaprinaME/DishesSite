using Microsoft.AspNetCore.Mvc;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class AddRecipesController : Controller
    {
        private readonly DishesSiteContext _context;

        public AddRecipesController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recipe = new Recipe
                {
                    Рецепт_Id = model.RecipeId,
                    Название_рецепта = model.RecipeName,
                    Описание = model.Description,
                    Ингредиенты = model.Ingredients,
                    Инструкции = model.Instructions
                };

                _context.Рецепты.Add(recipe);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}
