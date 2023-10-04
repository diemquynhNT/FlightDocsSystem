using DocumentService.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Dto
{
    public class DocumentFileVM
    {
   
        [MaxLength(100)]
        public string NameDoc { get; set; }

        public string? Note { get; set; }

        public string IdType { get; set; }

        public List<string> listGroup { get; set; }
        public IFormFile file { get; set; }



    }
}
