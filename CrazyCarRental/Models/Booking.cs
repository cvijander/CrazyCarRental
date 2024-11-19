namespace CrazyCarRental.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        public int CarId { get; set; }

        public Car selectedCar { get; set; }

        public int UserId { get; set; }

        public User selectedUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Pdv { get; set; }


         
    }
}
