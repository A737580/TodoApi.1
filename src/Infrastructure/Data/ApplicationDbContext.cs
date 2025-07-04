using Microsoft.EntityFrameworkCore;
using TodoApi.Application.Common.Interfaces; 
using TodoApi.Domain.Entities;  
using TodoApi.Domain.Common;  
using System.Reflection;  

namespace TodoApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
        public DbSet<Priority> Priorities => Set<Priority>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TodoItemTag> TodoItemTags => Set<TodoItemTag>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTimeOffset.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}