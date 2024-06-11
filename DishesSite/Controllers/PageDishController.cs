using Microsoft.AspNetCore.Mvc;

namespace DishesSite.Controllers
{
    public class PageDishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
