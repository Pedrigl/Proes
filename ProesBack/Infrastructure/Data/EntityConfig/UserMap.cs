using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.EntityConfig
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.loginId).IsRequired();

            builder.Property(x => x.UserType).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            
            builder.Property(x=>x.BirthDate).IsRequired();

            builder.Property(x => x.PictureUrl).HasMaxLength(200);

        }
    }
}
