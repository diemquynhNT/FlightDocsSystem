using DocumentService.Model;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace DocumentService.Services
{
    public interface IDocument
    {
        public List<DocumentsFlight> GetAllDocument();
        public List<DocumentsFlight> GetAllDocumentByIdUser(string idUser);
        public List<DocumentsFlight> GetAllDocumentByIdFlight(string idUser);
        public Task<DocumentsFlight> GetDocumentById(string id);
        public Task<DocumentsFlight> ImportDocument(string idUser,string IdFlight, List<string> listGroup, IFormFile file,DocumentsFlight documents);
        public Task<DocumentsFlight> UpdateDocument(string idUser);
 
        public Task<bool> DeleteDocument(string idDoc, string idUser);
        public bool HasReadAccess(string idGroup, string idDocument);
        public bool HasEditAccess(string idGroup, string idDocument);
    }
}
