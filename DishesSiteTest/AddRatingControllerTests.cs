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
    public class AddRatingControllerTests
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
                var controller = new AddRatingController(context);
                var model = new AddRatingViewModel
                {
                    RatingId = 1,
                    AverageRating = 4,
                    NumberOfRatings = 10,
                    RecipeId = 1
                };

                // Act
                var result = await controller.Add(model);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);

                var rating = await context.Рейтинг.FirstOrDefaultAsync();
                Assert.Equal(1, rating.Рейтинг_Id);
                Assert.Equal(4, rating.Средний_рейтинг);
                Assert.Equal(10, rating.Количество_оценок);
                Assert.Equal(1, rating.Рецепт_Id);
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
                var controller = new AddRatingController(context);
                var model = new AddRatingViewModel
                {
                    RatingId = 1,
                    AverageRating = 4,
                    NumberOfRatings = -5, // Invalid number of ratings
                    RecipeId = 1
                };

                controller.ModelState.AddModelError("NumberOfRatings", "The Number of Ratings must be positive.");

                // Act
                var result = await controller.Add(model);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Equal(model, viewResult.Model);
            }
        }
    }
}
