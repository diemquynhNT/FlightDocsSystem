using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{
    public class Groups
    {
        [Key]
        public string idGroup { get; set; }
        
        public DateTime createDate { get; set; }
        public string creator { get; set; }
        public string? note { get; set; }
        [Required]
        [MaxLength(100)]
        public string nameGroup { get; set; }

        public virtual ICollection<User> users { get; set; }
    }
}
