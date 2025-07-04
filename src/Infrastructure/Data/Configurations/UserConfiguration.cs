using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();  

            builder.HasIndex(u => u.Username)
                .IsUnique(); 

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();  

            builder.HasIndex(u => u.Email)
                .IsUnique();  

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(255)  
                .IsRequired();  

             
            builder.HasMany(u => u.TodoItems)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}