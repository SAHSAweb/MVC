using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Managers;
using System.Security.Cryptography;

namespace MVC.Controllers
{
    public class ClientController : Controller
    {
        Repository Rep { get; set; }
       
        public ClientController(Repository rp )
        {
            Rep = rp;      
        }
        public async Task<IActionResult> ClientIndex(int Id)
        {
            return View(await Rep.GetAsync(Id));
        }
        public async Task<IActionResult> BuyOrder(string Name, int id, int count, double price, int categoriesid)
        {
            await Rep.BuldingOrders(Name, count, price);
            await Rep.ChangeQuantity(categoriesid, id, count);          
            return RedirectToAction("ClientIndex", new { id = categoriesid });            
        }
        //public async Task<IActionResult> ShoppingCart()
        //{
        //    return View(await Rep.GetAsync());
        //}
    }
}
