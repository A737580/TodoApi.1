using TodoApi.Application.Common.Interfaces;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Enums;  

namespace TodoApi.Application.UseCases.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == request.UserId, cancellationToken);
            if (!userExists)
            {
                throw new Exception($"Пользователь с Id {request.UserId} не найден.");
            }

            var priorityExists = await _context.Priorities.AnyAsync(p => p.Id == request.PriorityId, cancellationToken);
            if (!priorityExists)
            {
                throw new Exception($"Приоритет с Id {request.PriorityId} не найден.");
            }

            var existingTagIds = await _context.Tags
                .Where(t => request.TagIds.Contains(t.Id))
                .Select(t => t.Id)
                .ToListAsync(cancellationToken);

            var nonExistingTagIds = request.TagIds.Except(existingTagIds).ToList();
            if (nonExistingTagIds.Any())
            {
                throw new Exception($"Один или несколько тегов не найдены: {string.Join(", ", nonExistingTagIds)}");
            }


            var todoItem = new TodoItem
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                PriorityId = request.PriorityId,
                Status = TodoItemStatus.Todo,  
                Created = DateTimeOffset.UtcNow,
                LastModified = DateTimeOffset.UtcNow
            };

            foreach (var tagId in request.TagIds)
            {
                todoItem.TodoItemTags.Add(new TodoItemTag
                {
                    TagId = tagId,
                    Created = DateTimeOffset.UtcNow,
                    LastModified = DateTimeOffset.UtcNow
                });
            }

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync(cancellationToken);

            return todoItem.Id;
        }
    }
}