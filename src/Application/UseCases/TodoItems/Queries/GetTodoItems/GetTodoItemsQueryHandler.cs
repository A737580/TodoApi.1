using TodoApi.Application.Common.Interfaces;
using TodoApi.Application.Common.Models; 

namespace TodoApi.Application.UseCases.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetTodoItemsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItemDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == request.UserId, cancellationToken);
            if (!userExists)
            {
                throw new Exception($"Пользователь с Id {request.UserId} не найден.");
            }

            return await _context.TodoItems
                .Where(t => t.UserId == request.UserId)
                .Include(t => t.Priority)  
                .Include(t => t.TodoItemTags)  
                    .ThenInclude(tt => tt.Tag)  
                .OrderBy(t => t.DueDate)  
                .Select(t => new TodoItemDto  
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    PriorityName = t.Priority!.Name,  
                    Tags = t.TodoItemTags.Select(tt => tt.Tag!.Name!).ToList(), 
                    UserName = t.User.Username 
                })
                .ToListAsync(cancellationToken);
        }
    }
}