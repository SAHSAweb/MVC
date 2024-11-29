using Microsoft.AspNetCore.Mvc;
using MVC.Managers;

using MVC.Interfaces;
using System.Numerics;
using MVC.Models;
using MVC.ViewModels;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        Repository Rep { get; set; }
        public CategoriesController(Repository rp)
        {
            Rep = rp;
        }
        
        public async Task<IActionResult> Index(int Id)
        {
            //// Проверка авторизации
            //if (HttpContext.Session.GetString("IsAuthorized") != "true")
            //{
            //    //return RedirectToAction("FormAuthorization", "Autorization");
            //return View(await Rep.GetAsync(Id));          
            //}
            //else return View("Client");
            return View(await Rep.GetAsync(Id));
        }

        public IActionResult Add(int id)
        {
            return View(Rep.AddProduct(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            model.Name = model.Name;
            model.Quantity = model.Quantity;
            model.Price = model.Price;
            await Rep.AddCategoryAsync(model);
                return RedirectToAction("Index", new { id = model.CategoriesId });         
        }
        public async Task<IActionResult> Delete(int id, int categoriesId)
        {
            if (categoriesId == 1 || categoriesId == 2 || categoriesId == 3 || categoriesId == 4)
            {
                await Rep.DeleteCategoryAsync(id, categoriesId);
                return RedirectToAction("Index", new { id = categoriesId });
            }
            else return BadRequest("Неправильний категорійний ідентифікатор.");            
        }
       
        public IActionResult Edit(int id, int categoriesId)
        {
            return View(Rep.CreateModel(id, categoriesId));
        }
        [HttpPost]
        public async Task< IActionResult> Edit(ProductViewModel model)
        {          
            await Rep.UpdateProductAsync(model);
            return RedirectToAction("Index", new { id = model.CategoriesId});           
        }
    }
}