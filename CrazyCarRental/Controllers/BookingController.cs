using CrazyCarRental.Models;
using CrazyCarRental.Util;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class BookingController : Controller
    {
        
        public async Task<IActionResult>Create(int carId, int userId)
        {
            IEnumerable<Car> cars = Garage.GenerateCars();

            Car car = cars.Single(x => x.CarId == carId);


            if(car == null || !car.IsAvailable)
            {
                return NotFound("The car is not available for booking");
            }

            
            return View(new Booking { BookingId=1, CarId = carId, Car = car, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1),TotalPrice = car.PricePerDay  });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task< IActionResult> Create(Booking booking)
        {
            IEnumerable<Car> cars = Garage.GenerateCars();

            Car car = cars.SingleOrDefault(x => x.CarId == booking.CarId);

            if(car == null || !car.IsAvailable )
            {
                return NotFound("The car is not available for booking");
            }

            var rentalDays = (booking.EndDate - booking.StartDate).Days;
            booking.TotalPrice = rentalDays * car.PricePerDay;

            if (ModelState.IsValid)
            {
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

        public IActionResult History()
        {
            return View();
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
