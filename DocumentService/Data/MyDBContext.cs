using DocumentService.Model;
using Microsoft.EntityFrameworkCore;
using DocumentService.Model;

namespace DocumentService.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        #region
        public DbSet<DocumentsFlight> Documents { get; set; }
        public DbSet<Flight> flights { get; set; }
        public DbSet<TypeDocument> typeDocuments { get; set; }
        public DbSet<Assignments> assignments { get; set; }
        public DbSet<Groups> groups { get; set; }
        public DbSet<Permisstions> permisstions { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>(ct =>
            {
                ct.HasKey(t => new { t.idGroup, t.idDoc });

                ct.HasOne(e => e.documents).
                   WithMany(e => e.Assignments)
                  .HasConstraintName("FK_assignment_document")
                  .HasForeignKey(e => e.idDoc);

                ct.HasOne(e => e.groups).
                WithMany(e => e.Assignments)
               .HasConstraintName("FK_phancong_group")
               .HasForeignKey(e => e.idGroup);
            });

            modelBuilder.Entity<Permisstions>(ct =>
            {
                ct.HasKey(t => new { t.idGroup, t.idType });

                ct.HasOne(e => e.type).
                   WithMany(e => e.Permisstions)
                  .HasConstraintName("FK_quyen_type")
                  .HasForeignKey(e => e.idType);

                ct.HasOne(e => e.groups).
                WithMany(e => e.Permisstions)
               .HasConstraintName("FK_quyen_group")
               .HasForeignKey(e => e.idGroup);
            });
        }


        }
}
