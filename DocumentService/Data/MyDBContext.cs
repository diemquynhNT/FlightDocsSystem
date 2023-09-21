using DocumentService.Model;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        #region
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Flight> flights { get; set; }
        public DbSet<TypeDocument> typeDocuments { get; set; }


        #endregion
    }
}
