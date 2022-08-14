using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRipository;
        
        public HomeController(IAllCars carRipository)
        {

            _carRipository = carRipository;
           
        }
        public IActionResult Index()
        {
            var homecars = new HomeViewModel
            {
                farcars = _carRipository.getFavCars
            };
            return View(homecars);
        }
    }
}
