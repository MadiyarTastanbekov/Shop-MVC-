using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController:Controller
    {
        private readonly IAllCars _carRipository;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRipository,ShopCart shopCart) {

            _carRipository = carRipository;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            _shopCart.ListShopItems = _shopCart.GetShopItem();
            ShopCartViewModel obj = new ShopCartViewModel { ShopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCartRedirec(int id)
        {
            var item = _carRipository.Cars.FirstOrDefault(i => i.id == id);
            if (_shopCart != null)
            {
                _shopCart.AddToCart(item);
            }
            
            return RedirectToAction("Index");
        }
    }
}
