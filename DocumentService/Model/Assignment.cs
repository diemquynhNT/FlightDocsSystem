using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Model
{
    public class Assignment
    {
        public string idGroup { get; set; } 
        public string idType { get; set; }
        public string permisstion { get; set; }

        public TypeDocument typeDocument { get; set; }

    }
}
