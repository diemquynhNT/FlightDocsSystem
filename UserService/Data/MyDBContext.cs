using Microsoft.EntityFrameworkCore;
using UserService.Model;

namespace UserService.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        #region
        public DbSet<User> users { get; set; }


        #endregion
    }
}
