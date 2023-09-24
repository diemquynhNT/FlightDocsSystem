using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        [Required]
        [MaxLength(100)]
        public string nameUser { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string emailAddress { get; set; }
        [Required]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string phone { get; set; }
        [Required]
        public bool statusUser { get; set; }

        public string idGroup { get; set; }
        [ForeignKey("idGroup")]
        public Groups groups { get; set; }


    }
}
