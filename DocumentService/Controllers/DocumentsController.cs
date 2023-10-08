using AutoMapper;
using AutoMapper.Features;
using DocumentService.Data;
using DocumentService.Dto;
using DocumentService.Model;
using DocumentService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocument _context;
        private readonly IMapper _mapper;
        private readonly IGroup _group;

        public DocumentsController(IDocument idocument,IMapper imapper,IGroup groups) {
            _context = idocument;
            _mapper = imapper;
            _group = groups;
        }
        
        [HttpGet("ListAllDocument")]
        public List<DocumentsFlight> ListAllDocument()
        {
            return _context.GetAllDocument();

        }
  
        [HttpGet("ListAllDocumentForUser")]
        public List<DocumentsFlight> ListAllDocumentForUser(string idUser)
        {
            return _context.GetAllDocumentByIdUser(idUser);

        }
        [HttpGet("ListAllDocumentForFlight")]
        public List<DocumentsFlight> ListAllDocumentForFlight(string ìdFlight)
        {
            return _context.GetAllDocumentByIdFlight(ìdFlight);

        }

        [HttpGet("GetDetail")]
        public Task<DocumentsFlight> GetDocumentById(string idDoc)
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
                var documents = _mapper.Map<DocumentsFlight>(doc);
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

        [HttpGet("GetDocument")]
        public async Task<IActionResult> GetDocumentById(string documentId, string groupId)
        {
            try {
                DocumentsFlight document =  await _context.GetDocumentById(documentId);
                var group = _group.GetGroupById(groupId);

                if (document != null && group != null)
                {
                    if (_context.HasReadAccess(groupId, documentId) || _context.HasEditAccess(groupId, documentId))
                    {
                        var docVM = _mapper.Map<DocumentVM>(document);
                        return Ok(docVM);
                    }

                    return Forbid("Khong co quyen truy cap");
                }

                return NotFound("khong tim thay");
            }
            catch (Exception)
            {
                throw;
            }
           
        }



    }
}
