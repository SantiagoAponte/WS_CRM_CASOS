using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class DBSolucionesContext : DbContext
    {
        public DBSolucionesContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<UserAppoinments>().HasKey (ci => new {ci.IdUser, ci.AppoinmentsId});
        }

        public DbSet<Casos> Casos { get; set; }

    }
}