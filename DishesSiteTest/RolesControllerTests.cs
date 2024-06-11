using DishesSite.Controllers;
using DishesSite.DataContext;
using DishesSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace DishesSite.Test.Controllers
{
    public class RolesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfRoles()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                var controller = new RolesController(context);
                var roles = new List<Roles>
                {
                    new Roles { Код_роли = 1, Название_роли = "Role 1" },
                    new Roles { Код_роли = 2, Название_роли = "Role 2" },
                    new Roles { Код_роли = 3, Название_роли = "Role 3" }
                };
                context.Роли.AddRange(roles);
                context.SaveChanges();

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Roles>>(viewResult.Model);
                Assert.Equal(roles.Count, model.Count);
            }
        }
    }
}
