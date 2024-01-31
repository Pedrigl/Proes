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

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new UserCoursesMap());
            modelBuilder.ApplyConfiguration(new CoursesMap());
            modelBuilder.ApplyConfiguration(new AssignmentMap());
        }
    }
}
