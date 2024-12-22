using CrazyCarRental.Controllers;
using CrazyCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCarRental
{
    public class CarRentalContext : DbContext
    {

        public static readonly ILoggerFactory loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
           builder.AddConsole();
            });


        public CarRentalContext(DbContextOptions<CarRentalContext> options) :base(options) { }

        public DbSet<Car> Cars { get;set; }
        
        public DbSet<Booking> Bookings { get;set; } 

        public DbSet<Review> Reviews { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
