using System.ComponentModel.DataAnnotations;

namespace CrazyCarRental.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car? Car { get; set; }

        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        //[DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        
        public DateTime EndDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage ="Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }        


         
    }
}
