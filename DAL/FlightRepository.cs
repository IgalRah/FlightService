using FlightService.DataAccess;
using FlightService.Model;
using System.Collections.Generic;
using System.Linq;

namespace FlightService.DAL
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDataContext _db;

        public FlightRepository(AppDataContext Db)
        {
            _db = Db;
        }


        // All Actions Functions
        public List<Flight> GetAllFlights()
        {
            return _db.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _db.Flights.Find(id);
        }

        public void InsertDataToPassanger(Passenger passenger)
        {
            _db.Passengers.Add(passenger);
            _db.SaveChanges();
        }
        public void InsertDataToBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        
    }
}
