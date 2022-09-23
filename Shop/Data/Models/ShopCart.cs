using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopCart
    {

        private readonly AppDbContext appDbContext;
        public ShopCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var content = serviceProvider.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(content) { ShopCartId = shopCartId };
        }
        public void AddToCart(Car car)
        {
           
            appDbContext.ShopCartItems.Add(new ShopCartItem { 
               
                ShopCartId = ShopCartId, 
                Car= car, 
                price = (int)car.price });
            appDbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItem()
        {
            return appDbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
        
    }
}
