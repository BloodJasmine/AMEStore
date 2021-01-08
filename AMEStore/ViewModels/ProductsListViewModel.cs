using AMEStore.Data.Models;
using System.Collections.Generic;


namespace AMEStore.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string CurrentCategory { get; set; }
    }
}
