﻿using CrazyCarRental.Models;
using CrazyCarRental.Util;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly CarRentalContext _context;

        public CarController(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string make, string model, decimal? minPrice, decimal? maxPrice, int pageCount, int pageSize = 10)
        {
            var cars =_context.Cars.AsQueryable();

           // var cars = Garage.GenerateCars();

           // cars = cars.Where(c => c.Make == make && c.Model == model);

            

            if(make != null)
            {
                cars = cars.Where(c => c.Make.ToLower() == make.ToLower().Trim());
            }

            if (model != null )
            {
                cars = cars.Where(c => c.Model.ToLower() == model.ToLower().Trim());
            }

            if (minPrice > 0)
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice);
            }

            if (maxPrice > 0 )
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice);
            }

            cars = cars.Skip(pageSize * pageCount).Take(pageSize);

            return View(cars);
        }

        


        public async Task<IActionResult> Details(int id)
        {
            var car = await _context.Cars.FindAsync(id);

           // var cars = Garage.GenerateCars();
           // var car = cars.SingleOrDefault(x => x.CarId == id);

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
                IsAvailable = true,
                ImageUrl = "golf_1_gti.jpg"

            });
            listOfCars.Add(new Car
            {
                CarId = 2,
                Make = "Audi",
                Model = "100",
                PricePerDay = 30M,
                IsAvailable = false,
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
