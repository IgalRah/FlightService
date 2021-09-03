using System.Collections.Generic;
using FlightService.Model;

namespace FlightService.DAL
{
    public interface IFlightRepository
    {
        List<Flight> GetAllFlights();
        Flight GetFlightById(int id);
    }
}
