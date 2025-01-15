using Microsoft.AspNetCore.Mvc;
using MVC.BL.Services;
using MVC.DAL.Entities;
using MVC.Interfaces;
using MVC.Model.Enams;
using MVC.Models;
using MVC.ServicesUI;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class AutorizationController : Controller
    {
        private readonly IUsersServiseUI<UserViewModel, UserTypes> _userService;
        public AutorizationController(IUsersServiseUI<UserViewModel, UserTypes> userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult FormAuthorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormAuthorization(string login, string password)
        {
            var users = _userService.GetAll(UserTypes.User);

            if (login == Admin.login && password == Admin.password)
            {
                //  HttpContext.Session.SetString("IsAuthorized", "true"); // установка флага авторизации
                return RedirectToAction("Admin", "User");
            }
            else if (users.Any(p => p.Name == login && p.Email == password))
            {
                // Если пользователь найден
                return RedirectToAction("User", "User");
            }

            else
            {
                ViewBag.Error = "Invalid login or password.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Registration() => View();
        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            var user = new UserViewModel() { Name = login, Email = password, Id = Guid.NewGuid() };
            if (login == Admin.login && password == Admin.password)
            {
                ViewBag.Error = "User with the same Name or Email already exists.";
                return View();
            }
            else
            {
                var result = _userService.Add(user);

                if (result)
                {
                    return RedirectToAction("FormAuthorization");
                }
                else
                {
                    ViewBag.Error = "User with the same Name or Email already exists.";
                    return View();
                }
            }
        }
    }
}
