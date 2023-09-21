using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Model
{
    public class Documents
    {
        [Key]
        public string IdDocument { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameDoc { get; set; }
        [Required]
        [MaxLength(100)]
        public string Creator { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Note { get; set; }
        [Required]
        public string version { get; set; }
        [Required]
        public string IdUser { get; set; }

        public string IdFlight { get; set; }
        [ForeignKey("IdFlight")]
        public Flight flight { get; set; }

        public string IdType { get; set; }
        [ForeignKey("IdType")]
        public TypeDocument typeDocument { get; set; }

    }
}
