using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Model.Enams;
using MVC.ViewModels;


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
        public async Task<IActionResult> ProductsIndexAsync(Products category,Guid userId)
        { 
            var result = await _productService.GetAllAsync(category);

            ViewBag.UserId = userId; 

            return View(result);
        }
        public async Task<IActionResult> ProductsOverviewAsync(Products category)
        {

            var result = await _productService.GetAllAsync(category);
            return View(result);
        }
    }
}
