using DocumentService.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentService.Dto
{
    public class DocumentVM
    {
        
        public string IdDocument { get; set; }
        public string NameDoc { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Note { get; set; }
        public string version { get; set; }
      

    }
}
