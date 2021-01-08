using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using AMEStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

            if (string.IsNullOrEmpty(category))
            {
                products = _AllProducts.AllProducts.OrderBy(i => i.Id);
                ViewBag.Title = "Все товары";
            }
            else 
            {
                if (string.Equals("figure", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Фигурки")).OrderBy(i => i.Id);
                    currCategory = "Фигурки";
                }
                else if (string.Equals("dakimakura", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Дакимакуры")).OrderBy(i => i.Id);
                    currCategory = "Дакимакуры";
                }
                else if(string.Equals("clothes", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _AllProducts.AllProducts.Where(i => i.Category.CategoryName.Equals("Одежда")).OrderBy(i => i.Id);
                    currCategory = "Одежда";
                }
                ViewBag.Title = currCategory;
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
