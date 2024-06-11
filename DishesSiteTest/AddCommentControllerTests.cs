using DishesSite.Controllers;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace DishesSite.Test.Controllers
{
    public class AddCommentControllerTests
    {
        [Fact]
        public async Task Add_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new AddCommentController(context);
                var model = new AddCommentViewModel
                {
                    CommentId = 1,
                    RecipeId = 1,
                    Author = "John Doe",
                    CommentText = "Great recipe!"
                };

                // Act
                var result = await controller.Add(model);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);

                var comment = await context.Комментарии.FirstOrDefaultAsync();
                Assert.Equal(1, comment.Комментарий_Id);
                Assert.Equal(1, comment.Рецепт_Id);
                Assert.Equal("John Doe", comment.Автор);
                Assert.Equal("Great recipe!", comment.Текст_комментария);
            }
        }

        [Fact]
        public async Task Add_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new AddCommentController(context);
                var model = new AddCommentViewModel
                {
                    CommentId = 1,
                    RecipeId = 1,
                    Author = "John Doe",
                    CommentText = "" // Invalid comment text
                };

                controller.ModelState.AddModelError("CommentText", "The CommentText field is required.");

                // Act
                var result = await controller.Add(model);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Equal(model, viewResult.Model);
            }
        }
    }
}
