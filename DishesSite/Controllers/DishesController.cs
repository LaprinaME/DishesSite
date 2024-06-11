using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class DishesController : Controller
    {
        private readonly DishesSiteContext _context;

        public DishesController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dishes = await _context.Блюда.ToListAsync();
            return View(dishes);
        }
    }
}
