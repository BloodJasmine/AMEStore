using AMEStore.Data.Models;
using System.Collections.Generic;

namespace AMEStore.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
