using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult User()
        {
            return View();
        } 
        public IActionResult Admin()
        {
            return View();
        }
    }
}
