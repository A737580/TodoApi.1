using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Persistence.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(t => t.Name)
                .IsUnique(); 

            builder.HasData(
                new Tag { Id = 1, Name = "норм", Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Tag { Id = 2, Name = "сейчас",   Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Tag { Id = 3, Name = "потом",   Created = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc), LastModified = new DateTime(2023, 1, 1, 10, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}