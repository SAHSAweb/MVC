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

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUiService<ProductViewModel> _productService;

        public CategoriesController(IUiService<ProductViewModel> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index(Products category)
        {
            var result = _productService.GetAll().Where(p => p.Category == category).ToList();
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
            //model.Name = model.Name;
            //model.Quantity = model.Quantity;
            //model.Price = model.Price;
             _productService.Add(model);

            return RedirectToAction("Index", new { category = model.Category });
        }
        public IActionResult Delete(Guid Id, Products _category)
        {           
                 _productService.Delete( Id);
                return RedirectToAction("Index", new { category = _category });
            
          //  else return BadRequest("Неправильний категорійний ідентифікатор.");
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


        //        public IActionResult Edit(int id, int categoriesId)
        //        {
        //            return View(Rep.CreateModel(id, categoriesId));
        //        }
        //        [HttpPost]
        //        public async Task< IActionResult> Edit(ProductViewModel model)
        //        {          
        //            await Rep.UpdateProductAsync(model);
        //            return RedirectToAction("Index", new { id = model.CategoriesId});           
        //       }
    }
}   