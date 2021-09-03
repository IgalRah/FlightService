using FlightService.DataAccess;
using FlightService.Model;

namespace FlightService.DAL
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AppDbContext _context;

        public PassengerRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public void CreatePassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }
    }
}