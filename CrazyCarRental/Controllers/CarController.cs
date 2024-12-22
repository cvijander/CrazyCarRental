using CrazyCarRental.Models;
using CrazyCarRental.Service;
using CrazyCarRental.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CrazyCarRental.Controllers
{
    public class CarController : Controller
    {
        // private readonly CarRentalContext _context;

        // private readonly ICarService _carService;

        private readonly IUnitOfWork _unitOfWork;


        //public CarController(CarRentalContext context)
        //{
        //    _context = context;
        //}

        //public CarController(ICarService carService)
        //{
        //    _carService = carService;
        //}

        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index(string make, string model, int? minPrice, int? maxPrice, int pageCount = 1 , int pageSize = 10)
        {
            //var cars =_context.Cars.AsQueryable();

            // var cars = _carService.GetAllCars();
            // var cars = Garage.GenerateCars();

            // cars = cars.Where(c => c.Make == make && c.Model == model);

            var cars = _unitOfWork.CarService.GetAllFilteredCars(make,model, minPrice, maxPrice);

            //if (make != null)
            //{
            //    cars = cars.Where(c => c.Make.ToLower() == make.ToLower().Trim());
            //}

            //if (model != null )
            //{
            //    cars = cars.Where(c => c.Model.ToLower() == model.ToLower().Trim());
            //}

            //if (minPrice > 0)
            //{
            //    cars = cars.Where(c => c.PricePerDay >= minPrice);
            //}

            //if (maxPrice > 0 )
            //{
            //    cars = cars.Where(c => c.PricePerDay <= maxPrice);
            //}

           cars = cars.Skip(pageSize * pageCount).Take(pageSize);

            return View(cars);
        }

        


        public async Task<IActionResult> Details(int id)
        {
            //var car = await _context.Cars.FindAsync(id);

            var car = _unitOfWork.CarService.GetCarById(id);

            // var cars = Garage.GenerateCars();
            // var car = cars.SingleOrDefault(x => x.CarId == id);

            if (car == null) return NotFound();
                        
            return View(car);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if(file != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\cars");
                    path = $"{path}\\{car.Make}_{car.Model}_{car.Year}.jpg";

                    FileStream stream = new FileStream(path, FileMode.Create);
                    file.CopyTo(stream);
                    car.ImageUrl= $"{car.Make}_{car.Model}_{car.Year}.jpg";

                }


                _unitOfWork.CarService.AddCar(car);
                _unitOfWork.SaveChanges();


                IEnumerable<Car> cars = _unitOfWork.CarService.GetAllCars();
                return View("Index", cars);
            }

            return View(car);            

            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = _unitOfWork.CarService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Car car, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var editCar = _unitOfWork.CarService.GetCarById(id);

                if(editCar == null )
                {
                    return NotFound();
                }

                editCar.Make = car.Make;
                editCar.Model = car.Model;
                editCar.PricePerDay = car.PricePerDay;
                editCar.IsAvailable = car.IsAvailable;
                editCar.Year = car.Year;
                editCar.Seats   = car.Seats;
                editCar.FuelType = car.FuelType;

                if (file != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\cars");
                    path = $"{path}\\{car.Make}_{car.Model}_{car.Year}.jpg";

                    FileStream stream = new FileStream(path, FileMode.Create);
                    file.CopyTo(stream);
                    car.ImageUrl = $"{car.Make}_{car.Model}_{car.Year}.jpg";

                }

                _unitOfWork.CarService.UpdateCar(editCar);
                _unitOfWork.SaveChanges();

                IEnumerable<Car> cars = _unitOfWork.CarService.GetAllCars();
                return View("Index", cars);

            }
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
