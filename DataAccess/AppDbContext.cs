using Microsoft.EntityFrameworkCore;
using FlightService.Model;

namespace FlightService.DataAccess
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
