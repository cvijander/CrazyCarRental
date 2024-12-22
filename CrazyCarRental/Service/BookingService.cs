using CrazyCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCarRental.Service
{
    public class BookingService : IBookingService
    {

        private readonly CarRentalContext _context;

        public BookingService(CarRentalContext context)
        {
            context = context;
        }

       
        public void AddBooking(Booking booking)
        {
            
            _context.Bookings.Add(booking);
            
        }

        public void DeleteBooking(int id)
        {
           
            var booking = _context.Bookings.Find(id);
            if(booking != null)
            {
                _context.Bookings.Remove(booking);
                
            }
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void UpdateBooking(Booking booking)
        {
          

            _context.Bookings.Update(booking);
            
        }
    }
        
   
}
