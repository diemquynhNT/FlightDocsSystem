using UserService.Data;
using UserService.Model;

namespace UserService.Services
{
    public class UserServices : IUser
    {
        private MyDBContext _context;

        public UserServices(MyDBContext context) {
            _context = context;
        }
        public Task<User> AddUser(User users)
        {
            throw new NotImplementedException();
        }

        public Task<User> ChangeAccount(User users)
        {
            throw new NotImplementedException();
        }

        public Task<string> ConfirmAccount(string idUser, string passWord)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(string idUser)
        {
            throw new NotImplementedException();
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

        public Task<User> ResetAccount(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> TerminateUser(List<User> listUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User users)
        {
            throw new NotImplementedException();
        }
    }
}
