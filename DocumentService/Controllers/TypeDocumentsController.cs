using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;
using DocumentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDocumentsController : ControllerBase
    {
        private readonly ITypeDocument _context;
        private readonly IMapper _mapper;

        public TypeDocumentsController(ITypeDocument context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet("ListAllType")]
        public List<TypeDocument> ListAllType()
        {
            return _context.GetAllType();

        }
        [HttpGet("ListAllPer")]
        public List<Permisstions> ListAllPer()
        {
            return _context.GetAllPer();

        }
        [HttpGet("GetDetail")]
        public Task<TypeDocument> GetTypeById(string idType)
        {
            return _context.GetById(idType);

        }

        [HttpPost("AddNewType")]
        public async Task<ActionResult> AddNewType(string idUser,[FromBody]TypeDocumentModel type )
        {
            try
            {
                var typeDocument = _mapper.Map<TypeDocument>(type);
                await _context.AddNewTypeDocument(typeDocument,idUser);
                foreach (var p in type.groupPer)
                {
                    _context.AddPermisstonGroup(p.idGroup,p.per, typeDocument);
                }
                return Ok("tao thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateType")]
        public async Task<IActionResult> UpdateType(string idType,[FromForm] TypeDocumentModel type)
        {
            var typeDoc = await _context.GetById(idType);
            if (typeDoc == null)
                return BadRequest("khong tim thay");
            _mapper.Map(type, typeDoc);
            await _context.UpdateTypeDocument(idType,typeDoc);
            return Ok(" cap nhat thanh cong");
        }


        [HttpDelete("DeleteType")]
        public async Task<ActionResult> DeleteType(string idType)
        {
            try
            {
                bool type = await _context.DeleteType(idType);
                if (type == true)
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
