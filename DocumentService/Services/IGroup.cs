using DocumentService.Model;


namespace DocumentService.Services
{
    public interface IGroup
    {
        public List<Groups> GetAllGroup();
        public Task<Groups> GetGroupById(string id);
        public Task<Groups> AddNewGroup(Groups group,string idUser);
        public Task<Groups> UpdateGroup(Groups group, string idGroup);
        public Task<bool> DeleteGroup(string idGroup);
    }
}
