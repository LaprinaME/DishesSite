using Microsoft.AspNetCore.Mvc;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class AddCommentController : Controller
    {
        private readonly DishesSiteContext _context;

        public AddCommentController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Комментарий_Id = model.CommentId,
                    Рецепт_Id = model.RecipeId,
                    Автор = model.Author,
                    Текст_комментария = model.CommentText
                };

                _context.Комментарии.Add(comment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}
