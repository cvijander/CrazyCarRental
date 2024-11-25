using CrazyCarRental.Models;

namespace CrazyCarRental.Util
{
    public class Garage
    {
        public static IEnumerable<Car> GenerateCars()
        {
            var cars = new List<Car>();
            Car lancerEvo6 = new Car()
            {
                CarId = 1,
                Make = "Mitsubishi",
                Model = "Lancer Evo VI",
                Year = 1999,
                PricePerDay = 224.5m,
                ImageUrl = "mitsubishi-evo-6-1999.jpg",
                Seats = 5,
                IsAvailable = true

            };

            cars.Add(lancerEvo6);

            Car imprezaSti = new Car()
            {
                CarId = 2,
                Make = "Subary",
                Model = "Impreza WRX Sti",
                Year = 2006,
                PricePerDay = 213.98m,
                Seats = 5,
                ImageUrl = "subary-impreza-wrx-sti-2006.jpg",
                IsAvailable = true
            };

            cars.Add(imprezaSti);

            Car lanchiaDelta = new Car()
            {
                CarId = 3,
                Make = "Lanchia",
                Model = "Delta HF Integrale",
                Year = 1992,
                PricePerDay = 350.78m,
                Seats = 5,
                ImageUrl = "lancia.jpg",
                IsAvailable = false
            };
            
            cars.Add(lanchiaDelta);

            Car toyotaSupra = new Car()
            {


                CarId = 4,
                Make = "Toyota",
                Model = "Supra MK4",
                Year = 1994,
                PricePerDay = 120.0m,
                Seats = 5,
                ImageUrl = "/images/toyota_supra_mk4.jpg",
                IsAvailable = true
            };

            cars.Add(toyotaSupra);

            Car nissanSkyline = new Car()
            {

                CarId = 5,
                Make = "Nissan",
                Model = "Skyline GT-R R34",
                Year = 1999,
                PricePerDay = 140.0m,
                Seats = 5,
                ImageUrl = "/images/nissan_skyline_r34.jpg",
                IsAvailable = true

            };

            cars.Add(nissanSkyline);

            Car mitsubishiLancer = new Car()
            {

                CarId = 6,
                Make = "Mitsubishi",
                Model = "Lancer Evolution VI",
                Year = 1999,
                PricePerDay = 100.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/mitsubishi_evo_vi.jpg"
            };

            cars.Add(mitsubishiLancer);

            Car mazdaRx7 = new Car()
            {

                CarId = 7,
                Make = "Mazda",
                Model = "RX-7 FD",
                Year = 1993,
                PricePerDay = 110.0m,
                IsAvailable = false,
                Seats = 2,
                ImageUrl = "/images/mazda_rx7_fd.jpg"
            };

            cars.Add(mazdaRx7);

            Car hondaNSX = new Car()
            {

                CarId = 8,
                Make = "Honda",
                Model = "NSX",
                Year = 1995,
                PricePerDay = 150.0m,
                IsAvailable = true,
                Seats = 2,
                ImageUrl = "/images/honda_nsx.jpg"
            };

            cars.Add(hondaNSX);

            Car toyotaCelica = new Car()
            {

                CarId = 9,
                Make = "Toyota",
                Model = "Celica GT-Four",
                Year = 1994,
                PricePerDay = 90.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/toyota_celica_gtfour.jpg"
            };

            cars.Add(toyotaCelica);

            Car mazdaMiata = new Car()
            {

                CarId = 10,
                Make = "Mazda",
                Model = "MX-5 Miata",
                Year = 1996,
                PricePerDay = 80.0m,
                IsAvailable = true,
                Seats = 2,
                ImageUrl = "/images/mazda_mx5_miata.jpg"
            };

            cars.Add(mazdaMiata);

            Car hondaCivicR = new Car()
            {
                CarId = 11,
                Make = "Honda",
                Model = "Civic Type R (EK9)",
                Year = 1997,
                PricePerDay = 70.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/honda_civic_ek9.jpg"
            };

            cars.Add(hondaCivicR);

            Car nissan300 = new Car()
            {

                CarId = 12,
                Make = "Nissan",
                Model = "300ZX",
                Year = 1990,
                PricePerDay = 85.0m,
                IsAvailable = false,
                Seats = 2,
                ImageUrl = "/images/nissan_300zx.jpg"
            };

            cars.Add(nissan300);

            Car mitshubishi3000gt = new Car()
            {
                CarId = 13,
                Make = "Mitsubishi",
                Model = "3000GT",
                Year = 1996,
                PricePerDay = 100.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/mitsubishi_3000gt.jpg"
            };

            cars.Add(mitshubishi3000gt);

            Car bmwM3 = new Car()
            {

                CarId = 14,
                Make = "BMW",
                Model = "M3 E36",
                Year = 1995,
                PricePerDay = 130.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/bmw_m3_e36.jpg"
            };

            cars.Add(bmwM3);

            Car fordMustang = new Car()
            {

                CarId = 15,
                Make = "Ford",
                Model = "Mustang SVT Cobra",
                Year = 1993,
                PricePerDay = 140.0m,
                IsAvailable = true,
                Seats = 5,
                ImageUrl = "/images/ford_mustang_svt_cobra.jpg"
            };

            cars.Add(fordMustang);

            Car toyotaMr2 = new Car()
            {
                CarId = 16,
                Make = "Toyota",
                Model = "MR2 Turbo",
                Year = 1991,
                PricePerDay = 95.0m,
                IsAvailable = true,
                Seats = 2,
                ImageUrl = "/images/toyota_mr2.jpg"
            };

            cars.Add(toyotaMr2);

            Car volkswagenCorrado = new Car()
            {

                CarId = 17,
                Make = "Volkswagen",
                Model = "Corrado VR6",
                Year = 1992,
                PricePerDay = 80.0m,
                IsAvailable = false,
                Seats = 5,
                ImageUrl = "/images/vw_corrado_vr6.jpg"
            };

            cars.Add(volkswagenCorrado);

            return cars;
        }

        public static IEnumerable<Booking> GenerateBookings()
        {
            List<Booking> bookings = new List<Booking>();

            bookings.Add(new Booking()
            {
                CarId = 2,
                BookingId = 1,
                UserId = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now,
                TotalPrice = 2560,
                Car = new Car()
                {
                    CarId = 2,
                    Make = "Subary",
                    Model = "Impreza WRX Sti",
                    Year = 2006,
                    PricePerDay = 213.98m,
                    Seats = 5,
                    ImageUrl = "subary-impreza-wrx-sti-2006.jpg",
                    IsAvailable = true
                }
            });

            bookings.Add(new Booking()
            {
                CarId = 2,
                BookingId = 2,
                UserId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5),
                TotalPrice = 2560,
                Car = new Car()
                {
                    CarId = 2,
                    Make = "Subary",
                    Model = "Impreza WRX Sti",
                    Year = 2006,
                    PricePerDay = 213.98m,
                    Seats = 5,
                    ImageUrl = "subary-impreza-wrx-sti-2006.jpg",
                    IsAvailable = true

                }
            });

            return bookings;
         }
    }

}