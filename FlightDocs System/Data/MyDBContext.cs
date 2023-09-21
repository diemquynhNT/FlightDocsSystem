using FlightDocs_System.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs_System.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<Airplane> airplanes { get; set; }
        #endregion
    }
}
