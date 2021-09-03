using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
