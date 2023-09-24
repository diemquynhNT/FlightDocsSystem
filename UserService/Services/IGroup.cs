using System.Text.RegularExpressions;

namespace UserService.Services
{
    public interface IGroup
    {
        public List<Group> GetAllGroup();
        public Task<Group> GetGroupById(string id);
        public Task<Group> AddNewGroup(Group group);
        public Task<Group> UpdateGroup(Group group, string idGroup);
        public Task<bool> DeleteGroup(string idGroup);
    }
}
