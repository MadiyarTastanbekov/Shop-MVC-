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
            shopCart.ListShopItems = shopCart.GetShopItem();
            if (shopCart.ListShopItems.Count==0) 
            {
                Mess();
            }
            var orderdetail = new OrderDetail();
            if (order.id == orderdetail.OrderId)
            {
                order.orderTime = DateTime.Now;
                appDbContext.Orders.Add(order);
                appDbContext.SaveChanges();

                var items = shopCart.ListShopItems;

                foreach (var el in items)
                {
                    orderdetail.CarId = el.Car.id;
                    orderdetail.OrderId = order.id;
                    orderdetail.price = el.Car.price;
                    appDbContext.OrderDetails.Add(orderdetail);
                }
            }
            appDbContext.SaveChanges();
        }
        private string Mess()
        {
            return "Count=0";
        }

    }
}
