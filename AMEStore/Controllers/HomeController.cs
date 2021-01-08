using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using AMEStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Controllers
{
    public class HomeController: Controller
    {
        private readonly IProducts _prodRep;

        public HomeController(IProducts prodRep, StoreCart storeCart)
        {
            _prodRep = prodRep;
        }

        public ViewResult Index()
        {
            var homeProducts = new HomeViewModel
            {
                FavProducts = _prodRep.FavProducts
            };
            ViewBag.Title = "Избранные товары";
            return View(homeProducts);
        }

    }
}
