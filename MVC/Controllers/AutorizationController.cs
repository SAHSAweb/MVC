using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AutorizationController : Controller
    {
        [HttpGet]
        public IActionResult FormAuthorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormAuthorization(string login, string password)
        {
            if(login == Admin.login && password == Admin.password)
            {
              //  HttpContext.Session.SetString("IsAuthorized", "true"); // установка флага авторизации
                return View("OK");
            }
            else return View();
        }
    }
}
