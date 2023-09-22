using DocumentService.Model;

namespace DocumentService.Services
{
    public interface IDocument
    {
        public List<Documents> GetAllDocument();
        public List<Documents> GetAllDocumentByIdUser(string idUser);
        public Task<Documents> GetDocumentById(string id);
        public Task<Documents> AddManulDocument();
        public Task<Documents> ImportDocument(string idUser,string IdFlight, IFormFile file,Documents documents);
        public Task<Documents> UpdateDocument(string idUser);
 
        public Task<bool> DeleteDocument(string idDoc, string idUser);
    }
}
