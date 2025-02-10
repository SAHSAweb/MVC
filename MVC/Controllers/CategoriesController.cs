using Microsoft.AspNetCore.Mvc;

using MVC.Interfaces;
using System.Numerics;
using MVC.Models;
using MVC.ViewModels;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using MVC.Model;
using MVC.Model.Enams;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IProductsServisUI<ProductViewModel, Products> _productService;

        public CategoriesController(IProductsServisUI<ProductViewModel, Products> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Products category)
        {
            var result = await _productService.GetAllAsync(category);
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductViewModel model)
        {
            model.Name = model.Name;
            model.Quantity = model.Quantity;
            model.Price = model.Price;
            model.Category = model.Category;
           await _productService.AddAsync(model);

            return RedirectToAction("Index", new { category = model.Category });
        }

        public async Task<IActionResult> DeleteAsync(Guid Id, Products _category)
        {           
                await _productService.DeleteAsync( Id);
                return RedirectToAction("Index", new { category = _category });
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid Id)
        {
           var model = await _productService.GetByIdAsync(Id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ProductViewModel model)
        {
             await _productService.UpdateAsync(model);
            return RedirectToAction("Index", new { category = model.Category });
        }
    }
}   