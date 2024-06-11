using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishesSite.DataContext;
using DishesSite.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DishesSite.Controllers
{
    public class DeleteCommentsController : Controller
    {
        private readonly DishesSiteContext _context;

        public DeleteCommentsController(DishesSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Комментарии.ToListAsync();
            var viewModel = new List<DeleteCommentsViewModel>();

            foreach (var comment in comments)
            {
                viewModel.Add(new DeleteCommentsViewModel
                {
                    Комментарий_Id = comment.Комментарий_Id,
                    Рецепт_Id = comment.Рецепт_Id,
                    Автор = comment.Автор,
                    Текст_комментария = comment.Текст_комментария
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Комментарий_Id)
        {
            var comment = await _context.Комментарии.FindAsync(Комментарий_Id);

            if (comment == null)
            {
                return NotFound();
            }

            _context.Комментарии.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
