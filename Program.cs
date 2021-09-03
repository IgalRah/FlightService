using System.IO;
using FlightService.DAL;
using FlightService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightService
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration();
            var connectionString = configuration.GetConnectionString("Default");

            using (var context = new AppDbContext(connectionString))
            {
                var flightRepository = new FlightRepository(context);
                var bookingRepository = new BookingRepository(context);
                var passengerRepository = new PassengerRepository(context);
                var entryPoint = new EntryPoint(flightRepository, bookingRepository, passengerRepository);
                entryPoint.Run();
            }
        }

        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                 .Build();
        }
    }
}
