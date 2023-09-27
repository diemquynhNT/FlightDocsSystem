using System.ComponentModel.DataAnnotations;

namespace UserService.Dto
{
    public class UserModel
    {
        [Required]
        [MaxLength(100)]
        public string nameUser { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string emailAddress { get; set; }
        [Required]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string phone { get; set; }
        public DateTime hireDate { get; set; }
        [Required]
        public string uerName { get; set; }
        [Required]
        public string passWord { get; set; }

        public string idGroup { get; set; }
    }
}
