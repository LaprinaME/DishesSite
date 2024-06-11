using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    public class PageRecipeController : Controller
    {
        // GET: /Recipes
        public IActionResult Index()
        {
            return View();
        }
    }
}
