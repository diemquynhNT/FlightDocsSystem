﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using UserService.Data;
using UserService.Dto;
using UserService.Model;

namespace UserService.Services
{
    public class UserServices : IUser
    {
        private MyDBContext _context;
        private GenerateAlphanumericId generateId;
        private readonly AppSettings _appSettings;

        public UserServices(MyDBContext context, IOptionsMonitor<AppSettings> optionsMonitor) {
            _context = context;
            generateId = new GenerateAlphanumericId();
            _appSettings = optionsMonitor.CurrentValue;
        }
        public bool ValidatePassword(string password)
        {
            string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$";
            bool isValid = Regex.IsMatch(password, passwordRegex);
            return isValid;
        }

        public bool ValidateEmail(string email)
        {
            var emailUser = _context.users.Where(t => t.emailAddress == email).FirstOrDefault();
            if (emailUser == null)
                return true;
            return false;
        }

        public bool ValidatePhone(string phones)
        {
            var p = _context.users.Where(t => t.phone == phones).FirstOrDefault();
            if (p == null)
                return true;
            return false;
        }

        public async Task<User> AddUser(User users)
        {
            users.idUser ="VJ"+ generateId.GenerateId(5);
            users.statusUser = true;
            _context.Add(users);
            _context.SaveChanges();
            return users;
        }

        public Task<User> ChangeAccount(User users)
        {
            throw new NotImplementedException();
        }

        public Task<string> ConfirmAccount(string idUser, string passWord)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(string idUser)
        {
            var user=_context.users.SingleOrDefault(t=>t.idUser==idUser);
            if (user == null)
                return false;
            _context.Remove(user);
            _context.SaveChanges();
            return true;
        

        }

        public List<User> GetAllUser()
        {
            return _context.users.ToList();
        }

        public async Task<User> GetUserById(string idUser)
        {
            return _context.users.Where(t => t.idUser == idUser).FirstOrDefault();
        }

        public bool IsValidUser(string idUser)
        {
            throw new NotImplementedException();
        }

        public string GetToken(User user)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var per = _context.groups.Where(t => t.idGroup == user.idGroup).FirstOrDefault();
            var tokenDescription = new SecurityTokenDescriptor
            {
                //đặc trưng người dùng
                //TRUYỀN vào danh sách claim
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.nameUser),
                    new Claim(ClaimTypes.Email, user.emailAddress),
                    new Claim("UserName", user.userName),
                    new Claim("Id", user.idUser.ToString()),
                    new Claim("Permission", per.permissionGroup),
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),

                // Adding roles to the token
                Claims = new Dictionary<string, object>
                {
                    { "roles", per.nameGroup }
                },
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtToken.CreateToken(tokenDescription);
            return jwtToken.WriteToken(token);//tra ve chuoi 
        }

        public async Task<User> LoginUser(LoginModel login)
        {
            var user = _context.users.SingleOrDefault(u => u.userName == login.UserName
            && u.passWord == login.Passworduser.ToString());
            return user;
        }

        public Task<User> LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> ResetAccount(User user)
        {
            user.statusUser = true;
            var newPassword = generateId.GenerateId(5);
            user.passWord = newPassword;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Contact", "contactcentersgt@gmail.com"));
            message.To.Add(new MailboxAddress("Tên người nhận", user.emailAddress));
            message.Subject = "Reset Account";
            message.Body = new TextPart("plain")
            {
                Text = "new password: " + newPassword
            };
            
            // Cấu hình SmtpClient
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtpClient.Authenticate("contactcentersgt@gmail.com", "akoi wjtt rpzd xpmw");

                // Gửi email
                smtpClient.Send(message);

                // Đóng kết nối
                smtpClient.Disconnect(true);
                _context.SaveChanges();
                return user;
            }
        }

        public async Task<User> TerminateUser(User user)
        {
            
            user.statusUser = false;
            _context.SaveChanges(true);
            return user;
            
          
        }

        public async Task<User> UpdateUser(User users)
        {
           
            _context.users.Update(users);
            _context.SaveChanges();
            return users;
        }
    }

     
    }
