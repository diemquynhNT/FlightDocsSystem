using System.ComponentModel.DataAnnotations;

namespace DocumentService.Dto
{
    public class TypeDocumentModel
    {
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }
        public string? Note { get; set; }
        public List<GroupPerVM> groupPer { get; set; }


    }
}
