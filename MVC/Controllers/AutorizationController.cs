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
        public async Task<IActionResult> FormAuthorizationAsync(string login, string password)
        {
            var users = await _userService.GetAllAsync(UserTypes.User);
            var user =  users.FirstOrDefault(p => p.Name == login && p.Email == password);

            if (login == Admin.login && password == Admin.password)
            {

                return RedirectToAction("Admin", "User");
            }

            else if (user != null)
            {
                return RedirectToAction("User", "User", new { id = user.Id });
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
        public async Task<IActionResult> RegistrationAsync(string login, string password)
        {
            var user = new UserViewModel() { Name = login, Email = password, Id = Guid.NewGuid() };
            if (login == Admin.login && password == Admin.password)
            {
                ViewBag.Error = "User with the same Name or Email already exists.";
                return View();
            }
            else
            {
                var result = await _userService.AddAsync(user);

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
