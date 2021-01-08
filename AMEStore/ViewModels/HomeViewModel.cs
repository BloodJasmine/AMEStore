using AMEStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FavProducts { get; set; }
    }
}
