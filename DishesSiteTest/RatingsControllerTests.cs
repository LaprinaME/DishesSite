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
    public class RatingsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfRatings()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new RatingsController(context);
                var ratings = new List<Rating>
                {
                    new Rating { Рейтинг_Id = 1, Средний_рейтинг = 4, Количество_оценок = 10, Рецепт_Id = 1 },
                    new Rating { Рейтинг_Id = 2, Средний_рейтинг = 3, Количество_оценок = 5, Рецепт_Id = 2 },
                    new Rating { Рейтинг_Id = 3, Средний_рейтинг = 4, Количество_оценок = 8, Рецепт_Id = 3 }
                };
                context.Рейтинг.AddRange(ratings);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Rating>>(viewResult.Model);
                Assert.Equal(ratings.Count, model.Count);
            }
        }
    }
}
