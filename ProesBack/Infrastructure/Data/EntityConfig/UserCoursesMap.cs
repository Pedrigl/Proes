using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.EntityConfig
{
    public class UserCoursesMap : IEntityTypeConfiguration <UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.ToTable("UserCourses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.CourseId).IsRequired();
        }
    }
    
}
