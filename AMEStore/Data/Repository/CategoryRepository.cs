using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using System.Collections.Generic;

namespace AMEStore.Data.Repository
{
    public class CategoryRepository : ICategories
    {
        private readonly AppDBContext appDBContext;
        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Category> AllCategories => appDBContext.Category;
    }
}
