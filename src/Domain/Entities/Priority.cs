
namespace TodoApi.Domain.Entities;

public class Priority : BaseAuditableEntity
{
    public string? Name { get; set; }
    public int Weight { get; set; }
    public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>(); 
}
