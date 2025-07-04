using TodoApi.Domain.Enums; // Для TodoItemStatus

namespace TodoApi.Application.Common.Models
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TodoItemStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public string? PriorityName { get; set; } // Добавим имя приоритета
        public List<string> Tags { get; set; } = new List<string>(); // Список имен тегов
        public string? UserName { get; set; } // Имя пользователя, которому принадлежит задача
    }
}