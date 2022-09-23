using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;
        private readonly AppDbContext _appDbContext;

        public CarsController(IAllCars iallcars, ICarsCategory icarscategory,AppDbContext appDbContext)
        {
            _allCars = iallcars;
            _carsCategory = icarscategory;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Details(int id)
        {
         var cars = _allCars.Cars.FirstOrDefault
        (m => m.id == id);
            return View(cars);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("name,shortDesc,longDesc,img,price,Category,categoryID")] Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _appDbContext.Cars.Add(car);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(ListView));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
              "Try again, and if the problem persists " +
              "see your system administrator.");

            }
            return View(car);

        }
       
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> EditPost(int id, Car car)
        {
            if (id != car.id)
            {
                return NotFound();
            }
            var carupdate = await _appDbContext.Cars.FirstOrDefaultAsync(s => s.id == id);
            if (await TryUpdateModelAsync<Car>(
                carupdate,
                "",
                s => s.name, s => s.price, s => s.shortDesc, s => s.longDesc))
            {
                try
                {
                    await _appDbContext.SaveChangesAsync();
                   return RedirectToAction(nameof(EditPost));
                }
                catch (DbUpdateException )
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(carupdate);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _appDbContext.Cars
                .FirstOrDefaultAsync(m => m.id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);
            _appDbContext.Cars.Remove(car);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("ListView");
        }
        [Route("Cars/ListView")]
        [Route("Cars/ListView/{category}")]
        public ViewResult ListView(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string carCategory = "";
            if (string.IsNullOrWhiteSpace(category))
            {
                cars = _allCars.Cars.OrderByDescending(i => i.id);
            }
            else
            {

                if (string.Equals("electro",category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    carCategory = "Электромобили";
                }
                if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                    carCategory = "Классические автомобили";
                }
            }
            var carobj = new CarsListViewModel
            {
                allcars = cars,
                carCaregory = carCategory
            };

            ViewBag.Title = "Страница с автомобилями";
            return View(carobj);
        }

    }
}
