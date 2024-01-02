using Microsoft.EntityFrameworkCore;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.EntityConfig
{
    public class NotificationMap: IEntityTypeConfiguration<Notification>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Message).HasMaxLength(255).IsRequired();

            builder.Property(x => x.IsRead).IsRequired();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.date).IsRequired();

            builder.Property(x => x.Type).IsRequired();

        }
    }
}
