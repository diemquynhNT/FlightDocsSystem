using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Model
{
    public class DocumentsFlight
    {
        [Key]
        public string IdDocument { get; set; }
        [MaxLength(100)]
        public string NameDoc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Note { get; set; }
        public string version { get; set; }
        [Required]
        [MaxLength(100)]
        public string IdUser { get; set; }

        public string IdFlight { get; set; }
        [ForeignKey("IdFlight")]
        public Flight flight { get; set; }

        public string IdType { get; set; }
        [ForeignKey("IdType")]
        public TypeDocument typeDocument { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}
