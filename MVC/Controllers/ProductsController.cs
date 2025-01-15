using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using MVC.Interfaces;
using MVC.Model.Enams;
using MVC.ViewModels;
using System.Security.Cryptography;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsServisUI<ProductViewModel, Products> _productService;

        public ProductsController(IProductsServisUI<ProductViewModel, Products> productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductsIndex(Products category)
        {
 
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }
        public IActionResult ProductsOverview(Products category)
        {

            var result = _productService.GetAll(category).ToList();
            return View(result);
        }
    }
}
