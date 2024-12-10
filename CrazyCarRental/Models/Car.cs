using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyCarRental.Models
{
    [Table("Car")]
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        [Required]
        public bool IsAvailable { get;set; }

        [Required]
        public int Year { get; set; }

        public int Seats { get; set; }

        public string FuelType { get; set; }
        public string ImageUrl { get; set; }
    }
}
