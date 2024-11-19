using CrazyCarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index(string make, string model, decimal? minPrice, decimal? maxPrice)
        {
            var cars = InitCars();

           // cars = cars.Where(c => c.Make == make && c.Model == model);

            if(!(make == null || make ==""))
            {
                cars = cars.Where(c => c.Make == make);
            }

            if (!(model == null || model == ""))
            {
                cars = cars.Where(c => c.Model == model);
            }

            if (!(minPrice == null || minPrice == 0))
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice);
            }

            if (!(minPrice == null || minPrice == 0))
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice);
            }


            return View(cars);
        }

        


        public IActionResult Details(int id)
        {
            var cars = InitCars();
            var car = cars.FirstOrDefault(x => x.CarId == id);

            if (car == null) return NotFound();
                        
            return View(car);
        }

        public IEnumerable<Car> InitCars()
        {
            var listOfCars = new List<Car>();
            listOfCars.Add(new Car
            {
                CarId = 1,
                Make = "VW",
                Model = "Golf",
                PricePerDay = 10.5M,
                isAvaliable = true,
                ImageUrl = "golf_1_gti.jpg"

            });
            listOfCars.Add(new Car
            {
                CarId = 2,
                Make = "Audi",
                Model = "100",
                PricePerDay = 30M,
                isAvaliable = false,
                ImageUrl = "audi_100_2.jpg"

            });
            listOfCars.Add(new Car
            {
                CarId = 3,
                Make = "Toyota",
                Model = "Corola",
                PricePerDay = 20M,

            });

            return listOfCars;

        }
    }
}
