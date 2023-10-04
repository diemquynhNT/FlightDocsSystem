using DocumentService.Model;

namespace DocumentService.Model
{
    public class Permisstions
    {
        public string idType { get; set; }  
        public string idGroup { get; set; }
        public string permisstion { get; set; }
        public Permisstions() { }

        public TypeDocument type { get; set; }
        public Groups groups { get; set; }
    }
}
