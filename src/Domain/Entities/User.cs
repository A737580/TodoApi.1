
namespace TodoApi.Domain.Entities;

public class User : BaseAuditableEntity 
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>(); 
}
