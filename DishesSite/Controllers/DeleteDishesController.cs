using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class DeleteDishesController : Controller
    {
        private readonly DishesSiteContext _context;

        public DeleteDishesController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dishes = await _context.Блюда.ToListAsync();
            var viewModel = new List<DeleteDishesViewModel>();

            foreach (var dish in dishes)
            {
                viewModel.Add(new DeleteDishesViewModel
                {
                    Блюдо_Id = dish.Блюдо_Id,
                    Название_блюда = dish.Название_блюда,
                    Описание = dish.Описание,
                    Информация = dish.Информация
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Блюдо_Id)
        {
            var dish = await _context.Блюда.FindAsync(Блюдо_Id);

            if (dish == null)
            {
                return NotFound();
            }

            _context.Блюда.Remove(dish);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
