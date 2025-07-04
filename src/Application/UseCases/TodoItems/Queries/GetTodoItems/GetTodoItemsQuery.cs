using TodoApi.Application.Common.Models;  

namespace TodoApi.Application.UseCases.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<List<TodoItemDto>>
    {
        public int UserId { get; set; }
    }
}