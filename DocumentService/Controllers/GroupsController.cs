using AutoMapper;
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
    public class GroupsController : ControllerBase
    {
        private readonly IGroup _context;
        private readonly IMapper _mapper;

        public GroupsController(IGroup context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet("ListAllGroup")]
        public List<Groups> ListAllGroup()
        {
            return _context.GetAllGroup();

        }
        [HttpGet("GetDetail")]
        public Task<Groups> GetGroupById(string idType)
        {
            return _context.GetGroupById(idType);

        }

        [HttpPost("AddNewGroup")]
        public async Task<ActionResult> AddNewGroup([FromForm] GroupsModel groupModel, string idUser)
        {
            try
            {
                var groups = _mapper.Map<Groups>(groupModel);
                await _context.AddNewGroup(groups, idUser);
                return Ok("tao thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> UpdateGroup(string idGroup, [FromForm] GroupsModel groupModel)
        {
            var groupFind = await _context.GetGroupById(idGroup);
            if (groupFind == null)
                return BadRequest("khong tim thay");
            _mapper.Map(groupModel, groupFind);
            await _context.UpdateGroup(groupFind, idGroup);
            return Ok(" cap nhat thanh cong");
        }
       

        [HttpDelete("DeleteGroup")]
        public async Task<ActionResult> DeleteGroup(string idGroup)
        {
            try
            {
                bool g = await _context.DeleteGroup(idGroup);
                if (g == true)
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
