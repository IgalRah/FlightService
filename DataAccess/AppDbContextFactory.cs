using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FlightService.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = Program.GetConfiguration();
            var connectionString = configuration.GetConnectionString("Default");
            return new AppDbContext(connectionString);
        }
    }
}