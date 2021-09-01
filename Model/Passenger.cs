using System.ComponentModel.DataAnnotations;

namespace FlightService.Model
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
