using System.ComponentModel.DataAnnotations;

namespace FlightDocs_System.Model
{
    public class Airplane
    {
        [Key]
        public string AirplaneNo { get; set; }
        [Required]
        [MaxLength(100)]
        public string AirplaneName { get; set;}
        [Required]
        public bool StatusAirplane { get; set;}
        [Required]
        public DateTime DateCreate { get; set;}
        [Required]
        public int Capacity { get; set;} 
    }
}
