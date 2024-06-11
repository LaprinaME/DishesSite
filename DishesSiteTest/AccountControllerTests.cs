using DishesSite.Controllers;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DishesSite.Tests
{
    public class AccountControllerTests
    {
        private readonly DbContextOptions<DishesSiteContext> _options;

        public AccountControllerTests()
        {
            _options = new DbContextOptionsBuilder<DishesSiteContext>()
                .UseInMemoryDatabase(databaseName: "Test_DishesSite_Database")
                .Options;
        }

        [Fact]
        public async void Login_ReturnsCorrectRedirectForValidUser()
        {
            // Arrange
            using (var context = new DishesSiteContext(_options))
            {
                var controller = new AccountController(context);
                var user = new Accounts
                {
                    Логин = "testuser",
                    Пароль = "testpassword",
                    Роли = new Roles { Код_роли = 1 }
                };
                context.Add(user);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new DishesSiteContext(_options))
            {
                var controller = new AccountController(context);
                var result = await controller.Login(new LoginViewModel { Login = "testuser", Password = "testpassword" }) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
                Assert.Equal("Menu", result.ControllerName);
            }
        }

        [Fact]
        public async void Register_ReturnsCorrectRedirectForValidRegistration()
        {
            // Arrange
            using (var context = new DishesSiteContext(_options))
            {
                var controller = new AccountController(context);
                var model = new RegisterViewModel
                {
                    Login = "testuser",
                    Password = "testpassword",
                    RoleCode = 1
                };

                // Act
                var result = await controller.Register(model) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
                Assert.Equal("Menu", result.ControllerName);
            }
        }
    }
}
