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
        public IActionResult Index(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            model.Name = model.Name;
            model.Quantity = model.Quantity;
            model.Price = model.Price;
            model.Category = model.Category;
            _productService.Add(model);

            return RedirectToAction("Index", new { category = model.Category });
        }

        public IActionResult Delete(Guid Id, Products _category)
        {           
                 _productService.Delete( Id);
                return RedirectToAction("Index", new { category = _category });
            
          //  else return BadRequest("Неправильний категорійний ідентифікатор.");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
           var model = _productService.GetById(Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
             _productService.Update(model);
            return RedirectToAction("Index", new { category = model.Category });
        }
    }



        //        public async Task<IActionResult> Index(int Id)
        //        {
        //            //// Проверка авторизации
        //            //if (HttpContext.Session.GetString("IsAuthorized") != "true")
        //            //{
        //            //    //return RedirectToAction("FormAuthorization", "Autorization");
        //            //return View(await Rep.GetAsync(Id));          
        //            //}
        //            //else return View("Client");
        //            return View(await Rep.GetAsync(Id));
        //        }


}   