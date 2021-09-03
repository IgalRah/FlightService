using FlightService.Model;

namespace FlightService.DAL
{
    public interface IPassengerRepository
    {
        void CreatePassenger(Passenger passenger);
    }
}