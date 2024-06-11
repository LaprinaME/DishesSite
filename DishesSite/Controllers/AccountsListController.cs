using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class AccountsListController : Controller
    {
        private readonly DishesSiteContext _context;

        public AccountsListController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _context.Аккаунты.Include(a => a.Роли).ToListAsync();
            return View(accounts);
        }
    }
}
