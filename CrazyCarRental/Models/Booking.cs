using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
        [FutureDate(ErrorMessage = "Start date must be in the future.")]
        
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
        public DateTime EndDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage ="Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }        


         
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is DateTime date)
            {
                if(date <= DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage ?? "The date must be in the future");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class DateGreaterThan : ValidationAttribute
    {
        private readonly string _comparison;

        public DateGreaterThan(string comparison)
        {
            _comparison = comparison;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is DateTime endDate)
            {
                var property = validationContext.ObjectType.GetProperty(_comparison);

                var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);
                                    
                if(comparisonValue.HasValue && endDate <= comparisonValue.Value)
                {
                    return new ValidationResult(ErrorMessage ?? "End date must be after the start date");
                }

            }

            return ValidationResult.Success;
        }
    }



}
