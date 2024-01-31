using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.EntityConfig
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();

            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.DueDate).IsRequired();
        }
    }
}
