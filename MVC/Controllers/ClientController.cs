using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using MVC.Interfaces;
using MVC.Managers;
using MVC.Model.Enams;
using System.Security.Cryptography;

namespace MVC.Controllers
{
    public class ClientController : Controller
    {
        IRepository Rep { get; set; }
       
        public ClientController(IRepository rp )
        {
            Rep = rp;      
        }
        public async Task<IActionResult> ClientIndex(Products type)
        {
            return View(await Rep.GetAsync(type));
        }
        public async Task<IActionResult> BuyOrder(string Name, int id, int count, double price, int categoriesid)
        {
            await Rep.BuldingOrders(Name, count, price);
            await Rep.ChangeQuantity(categoriesid, id, count);          
            return RedirectToAction("ClientIndex", new { id = categoriesid });            
        }

    }
}
