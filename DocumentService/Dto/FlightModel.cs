using System.ComponentModel.DataAnnotations;

namespace DocumentService.Dto
{
    public class FlightModel
    {
        [Required]
        public string AirplaneNo { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string PointOfLoading { get; set; }
        [Required]
        [MaxLength(100)]
        public string PointOfUnloading { get; set; }
        
      
      
    }
}
