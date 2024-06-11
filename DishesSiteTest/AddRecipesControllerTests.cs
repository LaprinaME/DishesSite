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
    public class AddRecipesControllerTests
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
                var controller = new AddRecipesController(context);
                var model = new AddRecipesViewModel
                {
                    RecipeId = 1,
                    RecipeName = "Test Recipe",
                    Description = "Test description",
                    Ingredients = "Test ingredients",
                    Instructions = "Test instructions"
                };

                // Act
                var result = await controller.Add(model);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);

                var recipe = await context.Рецепты.FirstOrDefaultAsync();
                Assert.Equal(1, recipe.Рецепт_Id);
                Assert.Equal("Test Recipe", recipe.Название_рецепта);
                Assert.Equal("Test description", recipe.Описание);
                Assert.Equal("Test ingredients", recipe.Ингредиенты);
                Assert.Equal("Test instructions", recipe.Инструкции);
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
                var controller = new AddRecipesController(context);
                var model = new AddRecipesViewModel
                {
                    RecipeId = 1,
                    RecipeName = "Test Recipe",
                    Description = "Test description",
                    Ingredients = "Test ingredients",
                    Instructions = "Test instructions"
                };

                controller.ModelState.AddModelError("Ingredients", "The Ingredients field is required.");

                // Act
                var result = await controller.Add(model);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Equal(model, viewResult.Model);
            }
        }
    }
}
