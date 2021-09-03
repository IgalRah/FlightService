using System.Linq;
using System.Collections.Generic;
using FlightService.DataAccess;
using FlightService.Model;

namespace FlightService.DAL
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _context;

        public FlightRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }



    }
}
