using Microsoft.EntityFrameworkCore;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.EntityConfig
{
    public class CoursesMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();

            builder.Property(x => x.TeacherId).IsRequired();

            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.Semester).IsRequired();
        }
    }
}
