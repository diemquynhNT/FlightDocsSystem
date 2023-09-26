using System.ComponentModel.DataAnnotations;

namespace UserService.Dto
{
    public class GroupsModel
    {

        [Required]
        [MaxLength(100)]
        public string nameGroup { get; set; }
        public string? note { get; set; }
     
    }
}
