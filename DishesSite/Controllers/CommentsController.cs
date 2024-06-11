using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class CommentsController : Controller
    {
        private readonly DishesSiteContext _context;

        public CommentsController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Комментарии.ToListAsync();
            return View(comments);
        }
    }
}
