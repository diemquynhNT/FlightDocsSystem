using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Dto;
using UserService.Model;
using UserService.Services;

namespace UserService.Controllers
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
        [Authorize("Admin")]
        public List<Groups> ListAllGroup()
        {
            return _context.GetAllGroup();

        }
        [Authorize("Admin")]
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
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateGroup(string idGroup, [FromForm] GroupsModel groupModel)
        {
            var groupFind = await _context.GetGroupById(idGroup);
            if (groupFind == null)
                return BadRequest("khong tim thay");
            _mapper.Map(groupModel, groupFind);
            await _context.UpdateGroup( groupFind,idGroup);
            return Ok(" cap nhat thanh cong");
        }
        [HttpPut("UpdatePermistion")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdatePermistion(string idGroup, string per)
        {
            var groupFind = await _context.GetGroupById(idGroup);
            if (groupFind == null)
                return BadRequest("khong tim thay");
            await _context.UpdatePermisstionGroup(idGroup, per);
            return Ok(" cap nhat thanh cong");
        }

        [HttpDelete("DeleteGroup")]
        [Authorize("Admin")]
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
