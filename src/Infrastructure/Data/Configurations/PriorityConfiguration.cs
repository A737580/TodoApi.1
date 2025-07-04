using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Persistence.Configurations
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();  

            builder.HasData(
                new Priority { Id = 1, Name = "Низкий", Weight = 1, Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Priority { Id = 2, Name = "Средний", Weight = 2, Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Priority { Id = 3, Name = "Высокий", Weight = 3, Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Priority { Id = 4, Name = "Срочный", Weight = 4, Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}