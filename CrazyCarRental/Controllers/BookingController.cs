using CrazyCarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(Booking booking)
        {
            return View(booking);
        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        public IActionResult ListOfPrevoius()
        {
            return View();
        }

        private IEnumerable<Booking> lists()
        {
            List<Booking> listOfBookings = new List<Booking>();
            listOfBookings.Add(new Booking
            {
                Id = 1,
                CarId = 1,
                UserId = 1,
                StartDate = new DateTime(2024, 12, 1),
                EndDate = new DateTime(2024,12,12),
                TotalPrice = 100,
                Pdv = 20,
            });

            listOfBookings.Add(new Booking
            {
                Id = 2,
                CarId = 2,
                UserId = 1,
                StartDate = new DateTime(2024, 10, 1),
                EndDate = new DateTime(2024, 10, 12),
                TotalPrice = 150,
                Pdv = 20,
            });

            listOfBookings.Add(new Booking
            {
                Id = 3,
                CarId = 3,
                UserId = 1,
                StartDate = new DateTime(2024, 08, 08),
                EndDate = new DateTime(2024, 10, 10),
                TotalPrice = 80,
                Pdv = 20,
            });

            return listOfBookings;
        } 
        

        
    }
    /*
    public int Id { get; set; }

    public int CarId { get; set; }

    public Car selectedCar { get; set; }

    public int UserId { get; set; }

    public User selectedUser { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal Pdv { get; set; }

    */

}
