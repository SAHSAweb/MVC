using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using MVC.Interfaces;
using MVC.Model.Enams;
using MVC.ViewModels;
using System.Security.Cryptography;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUiService<ProductViewModel> _productService;

        public UserController(IUiService<ProductViewModel> productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult UserIndex(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }
        //public async Task<IActionResult> BuyOrder(string Name, int id, int count, double price, int categoriesid)
        //{
        //    await Rep.BuldingOrders(Name, count, price);
        //    await Rep.ChangeQuantity(categoriesid, id, count);
        //    return RedirectToAction("ClientIndex", new { id = categoriesid });
        //}

    }
}
