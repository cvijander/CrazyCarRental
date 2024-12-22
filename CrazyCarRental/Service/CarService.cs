using CrazyCarRental.Models;
using System.Linq;

namespace CrazyCarRental.Service
{
    public class CarService : ICarService
    {
        private readonly CarRentalContext _context;

        public CarService(CarRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.Find(id);
        }


        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if(car != null)
            {
                _context.Cars.Remove(car);
                
            }

        }             

       
        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            
        }

        public IEnumerable<Car> GetAllFilteredCars(string make, string model, int? minPrice, int? maxPrice)
        {
           
            var cars = _context.Cars.AsQueryable();       



            if (make != null)
            {
                cars = cars.Where(c => c.Make.ToLower() == make.ToLower().Trim());
            }

            if (model != null)
            {
                cars = cars.Where(c => c.Model.ToLower() == model.ToLower().Trim());
            }

            if (minPrice > 0)
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice);
            }

            if (maxPrice > 0)
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice);
            }

            return cars;
            
        }
    }
}
