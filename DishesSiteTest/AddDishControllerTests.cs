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
    public class AddDishControllerTests
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
                var controller = new AddDishController(context);
                var model = new AddDishViewModel
                {
                    DishId = 1,
                    DishName = "Test Dish",
                    Description = "Test description",
                    Information = "Test information"
                };

                // Act
                var result = await controller.Add(model);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);

                var dish = await context.Блюда.FirstOrDefaultAsync();
                Assert.Equal(1, dish.Блюдо_Id);
                Assert.Equal("Test Dish", dish.Название_блюда);
                Assert.Equal("Test description", dish.Описание);
                Assert.Equal("Test information", dish.Информация);
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
                var controller = new AddDishController(context);
                var model = new AddDishViewModel
                {
                    DishId = 1,
                    DishName = "Test Dish",
                    Description = "Test description",
                    Information = "" // Invalid information
                };

                controller.ModelState.AddModelError("Information", "The Information field is required.");

                // Act
                var result = await controller.Add(model);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Equal(model, viewResult.Model);
            }
        }
    }
}
