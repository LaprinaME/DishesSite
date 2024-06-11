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
    public class DishesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfDishes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new DishesController(context);
                var dishes = new List<Dish>
                {
                    new Dish { Блюдо_Id = 1, Название_блюда = "Dish 1", Описание = "Description 1", Информация = "Information 1" },
                    new Dish { Блюдо_Id = 2, Название_блюда = "Dish 2", Описание = "Description 2", Информация = "Information 2" },
                    new Dish { Блюдо_Id = 3, Название_блюда = "Dish 3", Описание = "Description 3", Информация = "Information 3" }
                };
                context.Блюда.AddRange(dishes);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Dish>>(viewResult.Model);
                Assert.Equal(dishes.Count, model.Count);
            }
        }
    }
}
