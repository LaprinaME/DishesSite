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
    public class DeleteRecipesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfRecipes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new DeleteRecipesController(context);
                var recipes = new List<Recipe>
                {
                    new Recipe { Рецепт_Id = 1, Название_рецепта = "Recipe 1", Описание = "Description 1", Ингредиенты = "Ingredients 1", Инструкции = "Instructions 1" },
                    new Recipe { Рецепт_Id = 2, Название_рецепта = "Recipe 2", Описание = "Description 2", Ингредиенты = "Ingredients 2", Инструкции = "Instructions 2" },
                    new Recipe { Рецепт_Id = 3, Название_рецепта = "Recipe 3", Описание = "Description 3", Ингредиенты = "Ingredients 3", Инструкции = "Instructions 3" }
                };
                context.Рецепты.AddRange(recipes);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<DeleteRecipesViewModel>>(viewResult.Model);
                Assert.Equal(recipes.Count, model.Count);
            }
        }
    }
}
