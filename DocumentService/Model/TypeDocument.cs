using System.ComponentModel.DataAnnotations;

namespace DocumentService.Model
{
    public class TypeDocument
    {
        [Key]
        public string IdType { get; set; }
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }
        public string? Note { get; set; }

        [Required]
        public string Creator { get; set; }

        public virtual ICollection<DocumentsFlight> documents { get; set; }
        public virtual ICollection<Permisstions> Permisstions { get; set; }

    }
}
