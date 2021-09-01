using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Booking
    {
        [Key]
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int NumberOfBags { get; set; }
        public int BaggageWeight { get; set; }
    }
}
