using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public int NumberOfBags { get; set; }
        public int? BaggageWeight { get; set; }

        [Required]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
