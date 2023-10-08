using DocumentService.Data;
using DocumentService.Model;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
        public Task<DocumentsFlight> AddManulDocument()
        {
            throw new NotImplementedException();
        }


        public List<DocumentsFlight> GetAllDocument()
        {
            return _context.Documents.ToList();
        }

        public async Task<DocumentsFlight> GetDocumentById(string id)
        {
            return _context.Documents.Where(t=>t.IdDocument == id).FirstOrDefault();
        }
        
        public async Task<DocumentsFlight> ImportDocument(string idUser,string IdFlight, 
            List<string> listGroup, IFormFile file, DocumentsFlight documents)
        {
            var flights = _context.flights.Where(t => t.IdFlight == IdFlight).FirstOrDefault();
            if(flights.StatusFlight == false) {
                return null;
            }
            var id= "D" + GenerateRandomStringId(5);
            documents.IdDocument = id;
            documents.CreateDate = DateTime.Now;
            documents.IdUser = idUser;
            documents.IdFlight = IdFlight;
            documents.version = "1.0";
            if (documents.NameDoc == null)
                documents.NameDoc = file.FileName;

            foreach (var g in listGroup)
            {
                Assignments phancong = new Assignments();
                phancong.idGroup = g;
                phancong.idDoc = id ;
                _context.assignments.Add(phancong);
            }

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

        public void CopyFile(string nameFile)
        {
            var sourceDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DocumentUploads");
            var sourceFilePath = Path.Combine(sourceDirectory, "demo");

            var destinationDirectory = Directory.GetCurrentDirectory();
            var destinationFilePath = Path.Combine(destinationDirectory, nameFile);

            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Tệp nguồn không tồn tại.");
            }
            
            File.Copy(sourceFilePath, destinationFilePath, true);

        }
        //cap thi thi tạo lai doc
        public Task<DocumentsFlight> UpdateDocument(string idUser)
        {
            return null;
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

        public List<DocumentsFlight> GetAllDocumentByIdUser(string idUser)
        {
            return _context.Documents.Where(t => t.IdUser == idUser).ToList();
        }

        public List<DocumentsFlight> GetAllDocumentByIdFlight(string idFlight)
        {
            return _context.Documents.Where(t => t.IdUser == idFlight).ToList();
        }

        public bool HasReadAccess(string idGroup, string idDocument)
        {
            var per=_context.permisstions.Where(t=>t.idGroup==idGroup).FirstOrDefault();
            var doc=_context.assignments.Where(t=>t.idGroup==idGroup&&t.idDoc==idDocument).FirstOrDefault();
            if (doc != null && per.permisstion == "Readonly")
                return true;
            return false;
           
        }

        public bool HasEditAccess(string idGroup, string idDocument)
        {
            var per = _context.permisstions.Where(t => t.idGroup == idGroup).FirstOrDefault();
            var doc = _context.assignments.Where(t => t.idGroup == idGroup && t.idDoc == idDocument).FirstOrDefault();
            if (doc != null && per.permisstion == "Readedit")
                return true;
            return false;
        }
    }
}
