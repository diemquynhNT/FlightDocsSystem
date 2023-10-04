using DocumentService.Data;
using DocumentService.Model;

namespace DocumentService.Services
{
    public class GroupServices : IGroup
    {
        private MyDBContext _context;
        private GenerateAlphanumericId generateAlphanumericId;

        public GroupServices(MyDBContext context) {
            _context = context;
            generateAlphanumericId = new GenerateAlphanumericId();
        
        }
        public async Task<Groups> AddNewGroup(Groups group,string idUser)
        {
            group.idGroup = "G" + generateAlphanumericId.GenerateId(5);
            group.creator = idUser;
            group.createDate= DateTime.Now;
            _context.Add(group);
            _context.SaveChanges();
            return group;
          

        }

        public async Task<bool> DeleteGroup(string idGroup)
        {
            var groupUser=_context.groups.SingleOrDefault(t=>t.idGroup == idGroup);
            if (groupUser == null)
                return false;
            _context.groups.Remove(groupUser);
            _context.SaveChanges() ;
            return true;

        }

        public List<Groups> GetAllGroup()
        {
            return _context.groups.ToList();
        }

        public async Task<Groups> GetGroupById(string id)
        {
            return _context.groups.Where(t=>t.idGroup==id).FirstOrDefault();
        }

        public async Task<Groups> UpdateGroup(Groups group, string idGroup)
        {
            var g = _context.groups.SingleOrDefault(t => t.idGroup == idGroup);
            _context.groups.Update(g);
            _context.SaveChanges();
            return g;
        }

       
    }
}
