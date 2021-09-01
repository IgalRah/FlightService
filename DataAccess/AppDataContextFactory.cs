using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace FlightService.DataAccess
{
    public class AppDataContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            var services = Program.ConfigureServices().BuildServiceProvider();
            return services.GetService<AppDataContext>();
        }
    }
}
