using DishesSite.Controllers;
using DishesSite.DataContext;
using DishesSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DishesSite.Test.Controllers
{
    public class CommentsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfComments()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new CommentsController(context);
                var comments = new List<Comment>
                {
                    new Comment { Комментарий_Id = 1, Рецепт_Id = 1, Автор = "Author1", Текст_комментария = "Comment1" },
                    new Comment { Комментарий_Id = 2, Рецепт_Id = 1, Автор = "Author2", Текст_комментария = "Comment2" },
                    new Comment { Комментарий_Id = 3, Рецепт_Id = 2, Автор = "Author3", Текст_комментария = "Comment3" }
                };
                context.Комментарии.AddRange(comments);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Comment>>(viewResult.Model);
                Assert.Equal(comments.Count, model.Count);
            }
        }
    }
}
