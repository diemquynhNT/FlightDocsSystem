using DocumentService.Data;
using DocumentService.Model;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography;

namespace DocumentService.Services
{
    public class DocumentServices : IDocument
    {
        private readonly MyDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentServices(MyDBContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public string GenerateRandomStringId(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[(length / 2)];
                rng.GetBytes(bytes);
                return String.Concat(Array.ConvertAll(bytes, x => x.ToString("X2")));
            }
        }
        public Task<Documents> AddManulDocument()
        {
            throw new NotImplementedException();
        }


        public List<Documents> GetAllDocument()
        {
            return _context.Documents.ToList();
        }

        public async Task<Documents> GetDocumentById(string id)
        {
            return _context.Documents.Where(t=>t.IdDocument == id).FirstOrDefault();
        }

        public async Task<Documents> ImportDocument(string idUser,string IdFlight, IFormFile file, Documents documents)
        {
            documents.IdDocument = "D" + GenerateRandomStringId(5);
            documents.CreateDate = DateTime.Now;
            documents.IdUser = idUser;
            documents.IdFlight = IdFlight;
            documents.version = "1.0";
            if (documents.NameDoc == null)
                documents.NameDoc = file.FileName;

            if (file.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\DocumentUploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }
                using (FileStream fileStream = System.IO.File.Create(path + documents.NameDoc))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            _context.Documents.Add(documents);
            await _context.SaveChangesAsync();
            return documents;
        }

        //cap thi thi tạo lai doc
        public Task<Documents> UpdateDocument(string idUser)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteDocument(string idDoc, string idUser)
        {
            var doc =  _context.Documents.SingleOrDefault(t => t.IdUser == idUser && t.IdDocument == idDoc);
            if (doc != null)
            {
                string absolutePath = Path.Combine(_webHostEnvironment.WebRootPath, doc.NameDoc);
                 File.Delete(absolutePath);
                _context.Remove(doc);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Documents> GetAllDocumentByIdUser(string idUser)
        {
            return _context.Documents.Where(t => t.IdUser == idUser).ToList();
        }
    }
}
