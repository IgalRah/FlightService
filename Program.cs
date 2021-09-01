using System.IO;
using FlightService.DAL;
using FlightService.DataAccess;
using FlightService.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightService
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var entryPoint = serviceProvider.GetService<EntryPoint>();
            entryPoint.Run();
        }

        private static IConfiguration GetConfiguration()
        {
           return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();
        }

        public static IServiceCollection ConfigureServices()
        {
            var configuration = GetConfiguration();
            var connectionString = configuration.GetConnectionString("Default");

            return new ServiceCollection()
                .AddDbContext<AppDataContext>(options =>
                    options.UseSqlServer(connectionString))
                .AddSingleton<IFlightRepository, FlightRepository>()
                .AddSingleton<Display>()
                .AddSingleton<EntryPoint>();
        }
    }
}
