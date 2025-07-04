using TodoApi.Domain.Entities;

namespace TodoApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Priority> Priorities { get; }
    DbSet<Tag> Tags { get; }
    DbSet<TodoItemTag> TodoItemTags { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
