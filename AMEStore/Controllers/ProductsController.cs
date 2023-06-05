using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using AMEStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMEStore.Controllers
{
    public class ProductsController:Controller
    {
        private readonly IProducts _AllProducts;
        private readonly ICategories _AllCategories;

        public ProductsController(IProducts iProducts, ICategories iCategories)
        {
            _AllCategories = iCategories;
            _AllProducts = iProducts;
        }
        
        [Route("Products/List")]
        [Route("Products/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = "";
            
            switch (category)
            {
                case "figure":
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Фигурки")).OrderBy(i => i.Id);
                    currCategory = "Фигурки";
                    break;
                case "dakimakura":
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Дакимакуры")).OrderBy(i => i.Id);
                    currCategory = "Дакимакуры";
                    break;
                case "cosplay":
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Одежда")).OrderBy(i => i.Id);
                    currCategory = "Косплей";
                    break;
                default:
                    products = _AllProducts.AllProducts.OrderBy(i => i.Id);
                    ViewBag.Title = "Все товары";
                    break;
            }

            var prodObj = new ProductsListViewModel
            {
                AllProducts = products,
                CurrentCategory = currCategory
            };

            return View(prodObj);
        }
    }
}
