using DishesSite.Controllers;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DishesSite.Test.Controllers
{
    public class DeleteDishesControllerTests
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
                var controller = new DeleteDishesController(context);
                var dishes = new List<Dish>
                {
                    new Dish { Блюдо_Id = 1, Название_блюда = "Dish1", Описание = "Description1", Информация = "Information1" },
                    new Dish { Блюдо_Id = 2, Название_блюда = "Dish2", Описание = "Description2", Информация = "Information2" },
                    new Dish { Блюдо_Id = 3, Название_блюда = "Dish3", Описание = "Description3", Информация = "Information3" }
                };
                context.Блюда.AddRange(dishes);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<DeleteDishesViewModel>>(viewResult.Model);
                Assert.Equal(dishes.Count, model.Count);
            }
        }
    }
}
