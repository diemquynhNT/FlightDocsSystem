using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Dto;
using UserService.Model;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _context;
        private readonly IMapper _mapper;

        public UsersController(IUser context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUser()
        {
            return _context.GetAllUser();

        }
        [HttpGet("GetDetail")]
        public Task<User> GetUserById(string idUser)
        {
            return _context.GetUserById(idUser);

        }

        [HttpPost("AddNewUser")]
        public async Task<ActionResult> AddNewUser([FromForm] UserModel userModel)
        {
            try
            {
                var users = _mapper.Map<User>(userModel);
                await _context.AddUser(users);
                return Ok("tao thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string idUser, [FromForm] UserModel userModel)
        {
            var userFind = await _context.GetUserById(idUser);
            if (userFind == null)
                return BadRequest("khong tim thay");
            _mapper.Map(userModel, userFind);
            await _context.UpdateUser(userFind);
            return Ok(" cap nhat thanh cong");
        }


        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(string idUser)
        {
            try
            {
                bool user = await _context.DeleteUser(idUser);
                if (user == true)
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
