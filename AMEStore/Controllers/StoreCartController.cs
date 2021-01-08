using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using AMEStore.Data.Repository;
using AMEStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Controllers
{
    public class StoreCartController: Controller
    {
        private readonly IProducts _prodRep;
        private readonly StoreCart _storeCart;

        public StoreCartController(IProducts prodRep, StoreCart storeCart)
        {
            _prodRep = prodRep;
            _storeCart = storeCart;
        }

        public ViewResult Index()
        {
            var items = _storeCart.GetStoreItems();
            _storeCart.ListStoreItems = items;

            var obj = new StoreCartViewModel { StoreCart = _storeCart };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _prodRep.AllProducts.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _storeCart.AddToCart(item);
            }
            ViewBag.Title = "Корзина";
            return RedirectToAction("Index");
        }
    }
}
