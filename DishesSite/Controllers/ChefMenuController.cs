using Microsoft.AspNetCore.Mvc;

namespace DishesSite.Controllers
{
    public class ChefMenuController : Controller
    {
        // GET: /AdministrationMenu
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /AdministrationMenu
        [HttpPost]
        public IActionResult Index(string page)
        {
            if (!string.IsNullOrEmpty(page))
            {
                return Redirect(page);
            }
            else
            {
                // Если не выбрана страница, просто возвращаем текущую страницу
                return RedirectToAction("Index");
            }
        }
    }
}