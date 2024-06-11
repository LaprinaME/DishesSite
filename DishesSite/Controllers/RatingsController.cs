using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class RatingsController : Controller
    {
        private readonly DishesSiteContext _context;

        public RatingsController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ratings = await _context.Рейтинг.ToListAsync();
            return View(ratings);
        }
    }
}
