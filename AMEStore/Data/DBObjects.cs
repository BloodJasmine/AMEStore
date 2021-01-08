using AMEStore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context) 
        {
            
           
            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            //var to_del = context.Product.Where(x => x.Id != null);
            //context.Product.RemoveRange(to_del);
            //context.SaveChanges();

            if (!context.Product.Any())
            {              
                context.AddRange
                (
                    new Product
                    {
                        Name = "Микаса",
                        ShortDesc = "Фигурка Микасы",
                        LongDesc = "Фигурка песонажа - Микаса Аккерман. Из аниме - Атака Титанов",
                        Img = "/img/figure/Mikasa.jpg",
                        Price = 1000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Фигурки"]
                    },
                    new Product
                    {
                        Name = "Эрен",
                        ShortDesc = "Фигурка Эрена",
                        LongDesc = "Фигурка песонажа - Эрен Йегер. Из аниме - Атака Титанов",
                        Img = "/img/figure/Eren.jpg",
                        Price = 2500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Фигурки"]
                    },
                    new Product
                    {
                        Name = "Кирито",
                        ShortDesc = "Фигурка Кирито",
                        LongDesc = "Фигурка песонажа - Кирито. Из аниме - Мастера меча онлайн",
                        Img = "/img/figure/Kirito.jpg",
                        Price = 3500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Фигурки"]
                    },
                    new Product
                    {
                        Name = "Асуна",
                        ShortDesc = "Дакимакура Асуны",
                        LongDesc = "Дакимакура песонажа - Асуна. Из аниме - Мастера меча онлайн",
                        Img = "/img/dakimakura/Asuna.jpeg",
                        Price = 3500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Дакимакуры"]
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
                        Category = Categories["Одежда"]
                    }
               );
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories 
        {
            get 
            {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category { CategoryName = "Фигурки" , CategoryDesc = "Фигурки аниме персонажей" },
                        new Category { CategoryName = "Дакимакуры" , CategoryDesc = "Вытянутые подушки с рисунком аниме персонажа" },
                        new Category { CategoryName = "Одежда" , CategoryDesc = "Тематическая аниме одежда" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
