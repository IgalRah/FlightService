using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Flight
    {
        public int FlightId { get; set; }
        [Required]
        public int MaxBagsPerPassenger { get; set; }
        [Required]
        public int MaxBaggageWeightPerPassenger { get; set; }
        [Required]
        public string Destination { get; set; }
    }
}