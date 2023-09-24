using System.Text.RegularExpressions;

namespace UserService.Services
{
    public class GroupServices : IGroup
    {
        public Task<Group> AddNewGroup(Group group)
        {
            
        }

        public Task<bool> DeleteGroup(string idGroup)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetGroupById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> UpdateGroup(Group group, string idGroup)
        {
            throw new NotImplementedException();
        }
    }
}
