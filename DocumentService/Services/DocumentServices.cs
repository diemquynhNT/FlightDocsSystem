using DocumentService.Model;

namespace DocumentService.Services
{
    public class DocumentServices : IDocument
    {
        public Task<Documents> AddManulDocument()
        {
            throw new NotImplementedException();
        }

        public Task<Documents> DeleteDocument(string idDoc, string idUser)
        {
            throw new NotImplementedException();
        }

        public List<Documents> GetAllDocument()
        {
            throw new NotImplementedException();
        }

        public Task<Documents> GetDocumentById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Documents> ImportDocument(string idUser, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<Documents> UpdateDocument(string idUser)
        {
            throw new NotImplementedException();
        }
    }
}
