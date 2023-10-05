using AutoMapper;
using AutoMapper.Features;
using DocumentService.Data;
using DocumentService.Dto;
using DocumentService.Model;
using DocumentService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocument _context;
        private readonly IMapper _mapper;

        public DocumentsController(IDocument idocument,IMapper imapper) {
            _context = idocument;
            _mapper = imapper;
        }
        
        [HttpGet("ListAllDocument")]
        public List<Documents> ListAllDocument()
        {
            return _context.GetAllDocument();

        }
  
        [HttpGet("ListAllDocumentForUser")]
        public List<Documents> ListAllDocumentForUser(string idUser)
        {
            return _context.GetAllDocumentByIdUser(idUser);

        }
        [HttpGet("ListAllDocumentForFlight")]
        public List<Documents> ListAllDocumentForFlight(string ìdFlight)
        {
            return _context.GetAllDocumentByIdFlight(ìdFlight);

        }

        [HttpGet("GetDetail")]
        public Task<Documents> GetDocumentById(string idDoc)
        {
            return _context.GetDocumentById(idDoc);

        }
       
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile(string IdUser, string idFlight,
           [FromForm] DocumentFileVM doc)
        {
            if (doc.file == null)
            {
                return BadRequest();
            }

            try
            {
                var documents = _mapper.Map<Documents>(doc);
                await _context.ImportDocument(IdUser,idFlight,doc.listGroup,doc.file,documents);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("DeleteDocument")]
        public async Task<ActionResult> DeleteDocument(string idUser,string idDoc)
        {
            try
            {
                bool documents = await _context.DeleteDocument(idDoc,idUser);
                if (documents == true)
                    return Ok("xoa thanh cong");
                return BadRequest("loi");
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
