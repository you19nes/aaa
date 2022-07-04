using aaa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aaa.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Dossier> dossiers { get; set; }
        public DbSet<AttestionTravail> AttestionTravails { get; set; }
        public DbSet<AttestionDeSalaire> AttestionDeSalaires { get; set; }
        public DbSet<AttestionDeCesseison> AttestionDeCesseisons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // fill data via ContextSeed
            modelBuilder.UsersAndRolesCreate();
        }
    }
}
