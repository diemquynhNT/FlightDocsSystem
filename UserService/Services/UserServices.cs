using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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

        public UserServices(MyDBContext context) {
            _context = context;
            generateId = new GenerateAlphanumericId();
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

        public string GetToken(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string idUser)
        {
            return _context.users.Where(t => t.idUser == idUser).FirstOrDefault();
        }

        public bool IsValidUser(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUser()
        {
            throw new NotImplementedException();
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
