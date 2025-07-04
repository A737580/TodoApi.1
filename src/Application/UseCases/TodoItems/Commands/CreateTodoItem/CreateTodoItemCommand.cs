
namespace TodoApi.Application.UseCases.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public int UserId { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public int PriorityId { get; set; }  
        public List<int> TagIds { get; set; } = new List<int>();  
    }
}