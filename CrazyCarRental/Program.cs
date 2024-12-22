using CrazyCarRental.Service;
using Microsoft.EntityFrameworkCore;

namespace CrazyCarRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CarRentalContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information));


            builder.Services.AddScoped<ICarService,CarService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Car}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
