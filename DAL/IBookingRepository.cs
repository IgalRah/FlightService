using FlightService.Model;

namespace FlightService.DAL
{
    public interface IBookingRepository
    {
        void CreateBooking(Booking booking);
    }
}