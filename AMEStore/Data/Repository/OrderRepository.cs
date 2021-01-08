using AMEStore.Data.Interfaces;
using AMEStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMEStore.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContext appDBContext;
        private readonly StoreCart storeCart;
        public OrderRepository(AppDBContext appDBContext, StoreCart storeCart)
        {
            this.appDBContext = appDBContext;
            this.storeCart = storeCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContext.Order.Add(order);
            appDBContext.SaveChanges();

            var items = storeCart.ListStoreItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail() 
                {
                    ProductId = el.Product.Id,
                    OrderId = order.Id,
                    Price = el.Product.Price
                };
                appDBContext.OrderDetail.Add(orderDetail);
            }
            appDBContext.SaveChanges();
        }
    }
}
