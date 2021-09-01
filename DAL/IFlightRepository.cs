using System;
using System.Collections.Generic;
using FlightService.Model;

namespace FlightService.DAL
{
    public interface IFlightRepository : IDisposable
    {
        List<Flight> GetAllFlights();
        Flight GetFlightById(int id);
        void InsertDataToPassanger(Passenger passenger);
        void InsertDataToBooking(Booking booking);
    }
}
