﻿using CrazyCarRental.Models;
using CrazyCarRental.Service;
using CrazyCarRental.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrazyCarRental.Controllers
{
    public class BookingController : Controller
    {
       // private readonly CarRentalContext _context;

        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        //public BookingController(CarRentalContext context)
        //{
        //    _context = context;
        //}
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult>Create(int carId, int userId)
        {
           // var car = await _context.Cars.SingleOrDefaultAsync(x => x.CarId == carId);

            var car =_carService.GetCarById(carId);

           // IEnumerable<Car> cars = Garage.GenerateCars();

           // Car car = cars.Single(x => x.CarId == carId);


            if(car == null || !car.IsAvailable)
            {
                return NotFound("The car is not available for booking");
            }

            
            return View( new Booking { BookingId=1, CarId = carId, Car = car, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1),TotalPrice = car.PricePerDay  });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task< IActionResult> Create(Booking booking)
        {

            var car =_carService.GetCarById(booking.CarId);

           // var car = await _context.Cars.SingleOrDefaultAsync(x => x.CarId == booking.CarId);

           // IEnumerable<Car> cars = Garage.GenerateCars();

            //Car car = cars.SingleOrDefault(x => x.CarId == booking.CarId);

            if(car == null || !car.IsAvailable )
            {
                return NotFound("The car is not available for booking");
            }

            if(booking.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(booking.StartDate),"Start date must be in the future");
            }

            if(booking.EndDate < booking.StartDate)
            {
                ModelState.AddModelError(nameof(booking.EndDate), "End date must be aftter the start date");
            }                

           

            if (ModelState.IsValid)
            {
                int rentalDays = (booking.EndDate - booking.StartDate).Days;
                booking.TotalPrice = rentalDays * car.PricePerDay;

                if(booking.TotalPrice <= 0)
                {
                    ModelState.AddModelError(nameof(booking.TotalPrice), "Total price must be greather than 0");
                }

                return RedirectToAction("Confirmation", new { bookingId = booking.BookingId });
            }
            return View(booking);
        }

        [HttpPost]
        public IActionResult Booking(Booking booking)
        {
            return View(booking);
        }

        public async Task<IActionResult> Confirmation(int bookingId)
        {
            IEnumerable<Booking> bookings = Garage.GenerateBookings();
            Booking booking = bookings.SingleOrDefault(x => x.BookingId == bookingId);

            if (booking == null) 

               {
                 return NotFound();
               }

            booking.Car = InitCars().SingleOrDefault(x=> x.CarId == booking.CarId);

            return View(booking);
        }

        public IActionResult History(int userId)
        {
            var bookings = Garage.GenerateBookings();
            bookings = bookings.Where(b => b.UserId == userId);

            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        private IEnumerable<Booking> GenerateBookings()
        {
            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                BookingId = 1,
                CarId = 1,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 10.5M,
            });
            bookings.Add(new Booking
            {
                BookingId = 2,
                CarId = 2,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 300,
            });

            return bookings;
        }

        private IEnumerable<Car> InitCars()
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
