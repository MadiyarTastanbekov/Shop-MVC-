using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController:Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory carsCategory;

        public CarsController(IAllCars iallcars,ICarsCategory icarscategory)
        {
            allCars = iallcars;
            carsCategory = icarscategory;
        }
        [Route("")]
        [Route("Cars")]
        [Route("Cars/ListView")]
        public ViewResult ListView()
        {
            var cars = allCars.Cars;
            return View(cars);
        }

    }
}
