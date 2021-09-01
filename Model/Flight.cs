using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfSteats { get; set; }
        public int MaxBaggageWight { get; set; }
        public int MaxBagsPerPassenger { get; set; }
        public int MaxBaggageWeightPerPassenger { get; set; }
        public string Destination { get; set; }
    }
}