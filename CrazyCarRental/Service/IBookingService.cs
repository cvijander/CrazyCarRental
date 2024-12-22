using CrazyCarRental.Models;

namespace CrazyCarRental.Service
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        
        Booking GetBookingById(int id);

        void AddBooking(Booking booking);

        void UpdateBooking(Booking booking);

        void DeleteBooking(int id);
    }
}
