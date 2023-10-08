using System.ComponentModel.DataAnnotations;

namespace DocumentService.Model
{
    public class Flight
    {
        [Key]
        public string IdFlight { get; set; }
        [Required]
        [MaxLength(100)]
        public string PointOfLoading { get; set; }
        [Required]
        [MaxLength(100)]
        public string PointOfUnloading { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public bool StatusFlight { get; set; }
        [Required]
        public string AirplaneNo { get; set; }

        public virtual ICollection<DocumentsFlight> documents { get; set; }

    }
}
