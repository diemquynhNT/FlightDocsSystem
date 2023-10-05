using DocumentService.Data;
using DocumentService.Model;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DocumentService.Services
{
    public class TypeDocumentService : ITypeDocument
    {
        private readonly MyDBContext _context;
        private GenerateRandomId random;

        public TypeDocumentService(MyDBContext context)
        {
            _context = context;
            random = new GenerateRandomId();
          

           
        }
        public async Task<TypeDocument> AddNewTypeDocument(TypeDocument typeDocument,string idUser)
        {
            typeDocument.IdType = "Type-" + random.Generate(5);
            typeDocument.Creator = idUser;
            _context.Add(typeDocument);
            _context.SaveChanges();
            return typeDocument;
        }

        public void AddPermisstonGroup(string idGroup, string per, string idType)
        {
            Permisstions permisstions = new Permisstions();
            permisstions.idGroup = idGroup;
            permisstions.idType= idType;
            permisstions.permisstion = per;
            _context.Add(permisstions);
            _context.SaveChanges();
            
        }

        public async Task<bool> DeleteType(string idType)
        {
            var type=_context.typeDocuments.SingleOrDefault(t=>t.IdType == idType);
            if (type == null)
                return false;
            _context.typeDocuments.Remove(type);
            _context.SaveChanges();
            return true;

        }

        public List<TypeDocument> GetAllType()
        {
            return _context.typeDocuments.ToList();
        }

        public async Task<TypeDocument> GetById(string id)
        {
            return _context.typeDocuments.SingleOrDefault(t => t.IdType == id);
        }
        public async Task<TypeDocument> UpdateTypeDocument(string idType, TypeDocument type)
        {
            var typeDocument=_context.typeDocuments.SingleOrDefault(t=>t.TypeName==idType);
            _context.typeDocuments.Update(type);
            _context.SaveChanges();
            return typeDocument;
        }


       
    }
}
