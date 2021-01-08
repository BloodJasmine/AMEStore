using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AMEStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly StoreCart storeCart;
        public OrderController(IAllOrders allOrders, StoreCart storeCart)
        {
            this.allOrders = allOrders;
            this.storeCart = storeCart;
        }
        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            storeCart.ListStoreItems = storeCart.GetStoreItems();
            if (storeCart.ListStoreItems.Count == 0)
            {
                ModelState.AddModelError("","В корзине нет товаров");
            }
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
