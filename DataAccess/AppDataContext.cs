using Microsoft.EntityFrameworkCore;
using FlightService.Model;

namespace FlightService.DataAccess
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}
