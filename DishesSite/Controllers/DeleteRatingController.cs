using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using System.Threading.Tasks;
using System.Linq;
using DishesSite.ViewModels;

namespace DishesSite.Controllers
{
    public class DeleteRatingController : Controller
    {
        private readonly DishesSiteContext _context;

        public DeleteRatingController(DishesSiteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rating = await _context.Рейтинг.ToListAsync();
            var viewModel = new List<DeleteRatingViewModel>();

            foreach (var r in rating)
            {
                viewModel.Add(new DeleteRatingViewModel
                {
                    Рейтинг_Id = r.Рейтинг_Id,
                    Средний_рейтинг = r.Средний_рейтинг,
                    Количество_оценок = r.Количество_оценок,
                    Рецепт_Id = r.Рецепт_Id
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Рейтинг_Id)
        {
            var rating = await _context.Рейтинг.FindAsync(Рейтинг_Id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Рейтинг.Remove(rating);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
