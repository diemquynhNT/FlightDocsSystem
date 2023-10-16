using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Authorize(Roles = "admin")]
        public Task<User> GetUserById(string idUser)
        {
            return _context.GetUserById(idUser);

        }
        [HttpGet("GetString")]
        [Authorize(Roles = "admin")]
        public Task<string> GetRole(string id)
        {
            return _context.GetGroupName(id);

        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddNewUser")]
        public async Task<ActionResult> AddNewUser([FromBody] UserModel userModel)
        {
            try
            {
                bool checkPassword = _context.ValidatePassword(userModel.passWord);
                if(!checkPassword)
                    return BadRequest("pass khong du yeu cau");
                bool checkMail = _context.ValidateEmail(userModel.emailAddress);
                if (!checkMail)
                    return BadRequest("email da co nguoi su dung");
                bool checkPhone = _context.ValidatePhone(userModel.phone);
                if (!checkPhone)
                    return BadRequest("sdt da co nguoi su dung");
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
        public async Task<IActionResult> UpdateUser(string idUser, [FromBody] UserModel userModel)
        {
            var userFind = await _context.GetUserById(idUser);
            if (userFind == null)
                return BadRequest("khong tim thay");
            _mapper.Map(userModel, userFind);
            await _context.UpdateUser(userFind);
            return Ok(" cap nhat thanh cong");
        }

        [HttpPut("TerminateUser")]
        public async Task<IActionResult> TerminateUser([FromForm] List<string> listUser)
        {
            
            foreach (var user in listUser)
            {
                var u = await _context.GetUserById(user);
                if (u == null)
                    return BadRequest("loi");
                _context.TerminateUser(u);
            }    
            return Ok("da khoa tk");
        }

        [HttpPost("ResetAccount")]
        public async Task<IActionResult> ResetAccount([FromForm] string idUser)
        {
            var u = await _context.GetUserById(idUser);
            if (u == null)
                BadRequest("loi");
            _context.ResetAccount(u);
            return Ok("da reset tk");
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
        

        [HttpPost("Login")]
        public async Task<IActionResult> Validate([FromBody] LoginModel model)
        {
            try
            {
                User user = await _context.LoginUser(model);
                if (user==null)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "Invalid user/pass"
                    });
                }
                return Ok(new
                {
                    Success = true,
                    Message = "Authentication success",
                    Data = _context.GetToken(user)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       




    }
}
