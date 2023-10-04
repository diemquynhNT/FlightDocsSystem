using DocumentService.Model;

namespace DocumentService.Services
{
    public interface IDocument
    {
        public List<Documents> GetAllDocument();
        public List<Documents> GetAllDocumentByIdUser(string idUser);
        public List<Documents> GetAllDocumentByIdFlight(string idUser);
        public Task<Documents> GetDocumentById(string id);
        //add document
       
        public Task<Documents> AddManulDocument();
        public Task<Documents> ImportDocument(string idUser,string IdFlight, List<string> listGroup, IFormFile file,Documents documents);
        public Task<Documents> UpdateDocument(string idUser);
 
        public Task<bool> DeleteDocument(string idDoc, string idUser);
    }
}
