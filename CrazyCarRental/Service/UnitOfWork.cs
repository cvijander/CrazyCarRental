namespace CrazyCarRental.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalContext _context;

        public UnitOfWork(CarRentalContext context) 
        {
           
                _context = context;

            CarService = new CarService(context);

            BookingService = new BookingService(context);
        }
        



        public ICarService CarService { get; private set; }

        public IBookingService BookingService { get; private set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
