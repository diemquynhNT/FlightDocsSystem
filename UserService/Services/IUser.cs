using UserService.Dto;
using UserService.Model;

namespace UserService.Services
{
    public interface IUser
    {
        public List<User> GetAllUser();
        public Task<User> GetUserById(string idUser);
        public Task<User> AddUser(User users);
        public Task<User> UpdateUser(User users);
        public Task<bool> DeleteUser(string idUser);

        public bool IsValidUser(string idUser);
     
        public Task<User> LoginUser(LoginModel login);
        public Task<string> GetToken(User user);
        public Task<User> ChangeAccount(User users);
        public Task<string> ConfirmAccount(string idUser, string passWord);
        public Task<User> TerminateUser(User user);
        // khoi phuc va gui mk moi cho mail
        public Task<User> ResetAccount(User user);
        public bool ValidatePassword(string password);
        public bool ValidateEmail(string password);
        public bool ValidatePhone(string password);
        public Task<string> GetGroupName(string groupId);



    }
}
