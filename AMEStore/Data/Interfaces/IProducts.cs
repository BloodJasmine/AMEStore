using AMEStore.Data.Models;
using System.Collections.Generic;

namespace AMEStore.Data.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> FavProducts { get; }
        Product GetProduct(int prodId);
    }
}
