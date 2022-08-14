using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContext appDbContext,ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }


        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContext.Orders.Add(order);

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderdetail = new OrderDetail()
                {
                    CarId = el.Car.id,
                    OrderId = order.id,
                    price = (uint)el.Car.price
                };
                appDbContext.OrderDetails.Add(orderdetail);

            }
            appDbContext.SaveChanges();

        }
    }
}
