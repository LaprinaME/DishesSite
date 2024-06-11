using Microsoft.AspNetCore.Mvc;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class AddRatingController : Controller
    {
        private readonly DishesSiteContext _context;

        public AddRatingController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rating = new Rating
                {
                    Рейтинг_Id = model.RatingId,
                    Средний_рейтинг = model.AverageRating,
                    Количество_оценок = model.NumberOfRatings,
                    Рецепт_Id = model.RecipeId
                };

                _context.Рейтинг.Add(rating);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}
