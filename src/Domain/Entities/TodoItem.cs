
namespace TodoApi.Domain.Entities;

public class TodoItem : BaseAuditableEntity  
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TodoItemStatus Status { get; set; }  
    public DateTime DueDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int PriorityId { get; set; }
    public Priority? Priority { get; set; }

    public IList<TodoItemTag> TodoItemTags { get; set; } = new List<TodoItemTag>();  
}
