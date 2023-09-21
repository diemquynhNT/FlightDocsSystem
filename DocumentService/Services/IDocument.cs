using DocumentService.Model;

namespace DocumentService.Services
{
    public interface IDocument
    {
        public List<Documents> GetAllDocument();
        public Task<Documents> GetDocumentById(string id);
        public Task<Documents> AddManulDocument();
        public Task<Documents> ImportDocument(string idUser, IFormFile file);
        public Task<Documents> UpdateDocument(string idUser);
        public Task<Documents> DeleteDocument(string idDoc, string idUser);
    }
}
