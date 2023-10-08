using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using DocumentService.Model;

namespace DocumentService.Model
{
    public class Assignments
    {
        public string idGroup { get; set; } 
        public string idDoc { get; set; }

        public Groups groups { get; set; }
        public DocumentsFlight documents { get; set; }

    }
}
