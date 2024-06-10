﻿using Microsoft.AspNetCore.Mvc;
using DishesSite.DataContext;
using DishesSite.Models;
using DishesSite.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DishesSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly DishesSiteContext _context;

        public AccountController(DishesSiteContext context)
        {
            _context = context;
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем наличие пользователя в базе данных по логину и паролю
                var user = await _context.Аккаунты
                    .Include(u => u.Роли)
                    .FirstOrDefaultAsync(u => u.Логин == model.Login && u.Пароль == model.Password);

                if (user != null)
                {
                    // Проверяем, существует ли роль пользователя
                    if (user.Роли != null)
                    {
                        // Определяем код роли пользователя
                        var roleCode = user.Роли.Код_роли;

                        // Перенаправляем на соответствующую страницу в зависимости от роли
                        if (roleCode == 1)
                        {
                            // Роль с индексом 1 - перенаправление на страницу меню для сотрудников
                            return RedirectToAction("Index", "Menu");
                        }
                        else if (roleCode == 2)
                        {
                            // Роль с индексом 2 - перенаправление на страницу меню для администраторов
                            return RedirectToAction("Index", "AdministrationMenu");
                        }
                        else if (roleCode == 3)
                        {
                            // Роль с индексом 2 - перенаправление на страницу меню для администраторов
                            return RedirectToAction("Index", "ChefMenu");
                        }
                    }
                    else
                    {
                        // Если роль пользователя не определена, добавляем сообщение об ошибке в ModelState
                        ModelState.AddModelError(string.Empty, "Роль пользователя не определена");
                    }
                }
                else
                {
                    // Если пользователь не найден, добавляем сообщение об ошибке в ModelState
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                }
            }
            // Если ModelState невалиден или произошла ошибка при проверке, возвращаем представление с моделью для исправления ошибок
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверка на уникальность логина
                if (await _context.Аккаунты.AnyAsync(u => u.Логин == model.Login))
                {
                    ModelState.AddModelError("Login", "Пользователь с таким логином уже существует");
                    return View(model);
                }

                // Проверка на уникальность кода роли
                if (await _context.Роли.AllAsync(r => r.Код_роли != model.RoleCode))
                {
                    ModelState.AddModelError("RoleCode", "Роль с указанным кодом не существует");
                    return View(model);
                }

                // Создание нового аккаунта
                var account = new Accounts
                {
                    Логин = model.Login,
                    Пароль = model.Password,
                    Код_аккаунта = model.AccountCode
                };

                // Установка роли для аккаунта
                account.Роли = await _context.Роли.FindAsync(model.RoleCode);

                // Сохранение аккаунта в базе данных
                _context.Add(account);
                await _context.SaveChangesAsync();

                // Проверка роли и перенаправление на соответствующую страницу
                if (model.RoleCode == 1)
                {
                    // Роль администратора, перенаправление на главную страницу
                    return RedirectToAction("Index", "Menu");
                }
                else if (model.RoleCode == 2)
                {
                    // Роль пользователя, перенаправление на страницу меню
                    return RedirectToAction("Index", "AdministrationMenu");
                }
                else if (model.RoleCode == 3)
                {
                    // Роль пользователя, перенаправление на страницу меню
                    return RedirectToAction("Index", "ChefMenu");
                }
                else
                {
                    // Если роль не определена, перенаправляем на главную страницу
                    return RedirectToAction("Index", "Home");
                }
            }
            // Если ModelState невалиден, возвращаем представление с моделью для исправления ошибок
            return View(model);
        }


        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }
        // GET: /Account/RegistrationSuccess
        public IActionResult RegistrationSuccess()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}