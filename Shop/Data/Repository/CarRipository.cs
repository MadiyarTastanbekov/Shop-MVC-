using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRipository : IAllCars
    {
        private readonly AppDbContext appDbContext;
        public CarRipository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Car> Cars => appDbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDbContext.Cars.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDbContext.Cars.FirstOrDefault(p => p.id == carId);
    }
}
