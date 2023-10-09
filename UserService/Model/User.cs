using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model
{
    public class User
    {
        [Key]
        public string idUser { get; set; }  
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
        public DateTime hireDate { get; set; }

        public bool statusUser { get; set; }
        [Required]       
        public string userName { get; set; }
        [Required]
        public string passWord { get; set; }

        public string? idGroup { get; set; }
        


    }
}
