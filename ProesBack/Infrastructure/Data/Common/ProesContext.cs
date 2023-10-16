using Microsoft.EntityFrameworkCore;
using ProesBack.Domain.Entities;
using ProesBack.Infrastructure.Data.EntityConfig;

namespace ProesBack.Infrastructure.Data.Common
{
    public class ProesContext : DbContext
    {
        public ProesContext(DbContextOptions<ProesContext> options)
            : base(options) 
        {
           
        }        

        public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
