using Microsoft.AspNetCore.Mvc;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class AddDishController : Controller
    {
        private readonly DishesSiteContext _context;

        public AddDishController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDishViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dish = new Dish
                {
                    Блюдо_Id = model.DishId,
                    Название_блюда = model.DishName,
                    Описание = model.Description,
                    Информация = model.Information
                };

                _context.Блюда.Add(dish);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}
