using CrazyCarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            List<Car> listOfCars = new List<Car>();
            listOfCars.Add(new Car {
                CarId = 1,
                Make = "VW",
                Model = "Golf",
                PricePerDay = 10.5M,
                
            });
            listOfCars.Add(new Car
            {
                CarId = 2,
                Make = "Audi",
                Model = "S7",
                PricePerDay = 30M,

            });
            listOfCars.Add(new Car
            {
                CarId = 3,
                Make = "Toyota",
                Model = "Corola",
                PricePerDay = 20M,

            });
            return View(listOfCars);
        }

        public IActionResult Details(int id)
        {
            List<Car> listOfCars = new List<Car>();
            listOfCars.Add(new Car
            {
                CarId = 1,
                Make = "VW",
                Model = "Golf",
                PricePerDay = 10.5M,

            });
            listOfCars.Add(new Car
            {
                CarId = 2,
                Make = "Audi",
                Model = "S7",
                PricePerDay = 30M,

            });
            listOfCars.Add(new Car
            {
                CarId = 3,
                Make = "Toyota",
                Model = "Corola",
                PricePerDay = 20M,

            });


            var car = listOfCars.FirstOrDefault(c => c.CarId == id);
            return View(car);
        }
    }
}
