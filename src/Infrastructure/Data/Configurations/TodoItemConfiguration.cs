using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums; // Для TodoItemStatus

namespace TodoApi.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(1000);  

            builder.Property(t => t.Status)
                .HasConversion<string>()  
                .IsRequired();

            builder.Property(t => t.DueDate)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithMany(u => u.TodoItems)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(t => t.Priority)
                .WithMany(p => p.TodoItems)
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}