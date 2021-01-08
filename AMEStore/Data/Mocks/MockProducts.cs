using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Data.Mocks
{
    public class MockProducts : IProducts
    {
        private readonly ICategories _categoriesProduct = new MockCategories();
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Name = "Mikasa",
                        ShortDesc = "Фигурка Микасы",
                        LongDesc = "Фигурка песонажа - Микаса Аккерман. Из аниме - Атака Титанов",
                        Img = "/img/figure/Mikasa.jpg",
                        Price = 1000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoriesProduct.AllCategories.FirstOrDefault(cat => cat.CategoryName == "Фигурки")
                    },
                    new Product
                    {
                        Name = "Eren",
                        ShortDesc = "Фигурка Эрена",
                        LongDesc = "Фигурка песонажа - Эрен Йегер. Из аниме - Атака Титанов",
                        Img = "/img/figure/Eren.jpg",
                        Price = 2500,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoriesProduct.AllCategories.FirstOrDefault(cat => cat.CategoryName == "Фигурки")
                    },
                    new Product
                    {
                        Name = "Kirito",
                        ShortDesc = "Фигурка Кирито",
                        LongDesc = "Фигурка песонажа - Кирито. Из аниме - Мастера меча онлайн",
                        Img = "/img/figure/Kirito.jpg",
                        Price = 3500,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoriesProduct.AllCategories.FirstOrDefault(cat => cat.CategoryName == "Фигурки")
                    },
                    new Product
                    {
                        Name = "Asuna",
                        ShortDesc = "Дакимакура Асуны",
                        LongDesc = "Дакимакура песонажа - Асуна. Из аниме - Мастера меча онлайн",
                        Img = "/img/dakimakura/Asuna.jpeg",
                        Price = 3500,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoriesProduct.AllCategories.FirstOrDefault(cat => cat.CategoryName == "Дакимакуры")
                    },
                    new Product
                    {
                        Name = "Плащ Survey Corps",
                        ShortDesc = "Плащ развед отряда.",
                        LongDesc = "Плащ разведывательного отряда. Из аниме - Атака титанов",
                        Img = "/img/clothes/scout.jpg",
                        Price = 1500,
                        IsFavourite = false,
                        Available = false,
                        Category = _categoriesProduct.AllCategories.FirstOrDefault(cat => cat.CategoryName == "Одежда")
                    }
                };
            }
        }

        public IEnumerable<Product> FavProducts { get => throw new NotImplementedException(); }

        public Product GetProduct(int prodId)
        {
            throw new NotImplementedException();
        }
    }
}
