using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Data.Models
{
    public class StoreCart
    {
        private readonly AppDBContext appDBContext;
        public StoreCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public string StoreCartId { get; set; }
        public List<StoreCartItem> ListStoreItems { get; set; }

        public static StoreCart GetCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string storeCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", storeCartId);

            return new StoreCart(context) { StoreCartId = storeCartId };
        }

        public void AddToCart(Product product)
        {
            appDBContext.StoreCartItem.Add
            (
            new StoreCartItem 
            {
                StoreCartId = StoreCartId,
                Product = product,
                Price = product.Price
            }
            );

            appDBContext.SaveChanges();
        }

        public List<StoreCartItem> GetStoreItems() 
        {
            return appDBContext.StoreCartItem.Where(c => c.StoreCartId == StoreCartId).Include(s => s.Product).ToList();
        }
    }
}
