using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using System.Collections.Generic;

namespace AMEStore.Data.Mocks
{
    public class MockCategories: ICategories
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Фигурки" , CategoryDesc = "Фигурки аниме персонажей" },
                    new Category { CategoryName = "Дакимакуры" , CategoryDesc = "Вытянутые подушки с рисунком аниме персонажа" },
                    new Category { CategoryName = "Одежда" , CategoryDesc = "Тематическая аниме одежда" }
                };
            }
        }
    }
}
