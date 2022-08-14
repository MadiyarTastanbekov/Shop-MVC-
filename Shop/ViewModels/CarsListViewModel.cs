using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CarsListViewModel
    {
       public  IEnumerable<Car> allcars { get; set; }
         public string carCaregory { get; set; }
    }
}
