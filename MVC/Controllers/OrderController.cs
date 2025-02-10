using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Model;
using MVC.Model.Enams;
using MVC.ViewModels;
using MVC.BL.Interfaces;
using MVC.Models;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService<OrderViewModel> _orderService;

        private readonly IProductsServisUI<ProductViewModel, Products> _productService;
        public OrderController(IOrderService<OrderViewModel> orderService,
            IProductsServisUI<ProductViewModel, Products> productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        public async Task<IActionResult> IndexAsync(Guid userId, string name,
            int amount, decimal price, Products category, Guid productId)
        {
           await _productService.UpdeteProductQuantityAsync(productId, amount);

            var order = new OrderViewModel
            {
                Id = Guid.NewGuid(),
                ProductName = name,
                Amount = amount,                // Количество товара
                UserId = userId,    // ID пользователя
                Price = price,
                ProductId = productId
            };
           await _orderService.AddAsync(order);
            return RedirectToAction("ProductsIndex", "Products", new { userId = userId, category = category });
        }
        public async Task<IActionResult> OrdersCartAsync(Guid userId)
        {
            var result = await _orderService.GetAllAsync(userId);

            ViewBag.UserId = userId;

            return View(result);
        }
        public IActionResult OrdersPayment(Guid userId, string totalPrice)
        {
            ViewBag.UserId = userId;
            ViewBag.TotalPrice = totalPrice;
            return View();
        }
        public async Task<IActionResult> ProcessPaymentAsync(Guid userId, string totalPrice, string name,
            string surname, string numberCard, string cvv)
        {

            var result = await _orderService.SendCustomerBankInfoAsync(userId, totalPrice, name,
                                                 surname, numberCard, cvv);
            if (result == true)
            {
                await _orderService.DeleteAllOrdersAsync(userId);
                decimal parsedTotalPrice = Convert.ToDecimal(totalPrice); // или просто (decimal)totalPrice
                ViewBag.TotalPrice = parsedTotalPrice;
                ViewBag.UserId = userId;
                return View();
            }
            else
            {
                TempData["Error"] = "Invalid process of paumnt.";
                return RedirectToAction ("OrdersPayment");
            }
        }

        public async Task<IActionResult> OrderDeleteAsync(Guid Id, Guid userId)
        {
            await _orderService.DeleteAsync(Id);
            return RedirectToAction("OrdersCart", new { userId });
        }
    }
}
