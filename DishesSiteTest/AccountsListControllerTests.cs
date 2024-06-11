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
    public class AccountsListControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfAccounts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DishesSiteContext(options))
            {
                context.Аккаунты.AddRange(
                    new Accounts { Код_аккаунта = 1, Логин = "user1", Пароль = "password1", Роли = new Roles { Код_роли = 1, Название_роли = "Admin" } },
                    new Accounts { Код_аккаунта = 2, Логин = "user2", Пароль = "password2", Роли = new Roles { Код_роли = 2, Название_роли = "User" } }
                );
                context.SaveChanges();
            }

            using (var context = new DishesSiteContext(options))
            {
                var controller = new AccountsListController(context);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Accounts>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }
    }
}
