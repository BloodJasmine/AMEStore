using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AMEStore.Data.Repository
{
    public class ProductRepository: IProducts
    {
        private readonly AppDBContext appDBContext;
        public ProductRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Product> AllProducts => appDBContext.Product.Include(p => p.Category);

        public IEnumerable<Product> FavProducts => appDBContext.Product.Where(p => p.IsFavourite).Include(c => c.Category);

        public Product GetProduct(int prodId) => appDBContext.Product.FirstOrDefault(p => p.Id == prodId);
    }
}
