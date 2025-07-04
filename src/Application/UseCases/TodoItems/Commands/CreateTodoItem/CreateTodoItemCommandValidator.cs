using FluentValidation;

namespace TodoApi.Application.UseCases.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("Id пользователя должен быть указан.");  

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Заголовок задачи не может быть пустым.")
                .MaximumLength(200).WithMessage("Заголовок задачи не может превышать 200 символов.");

            RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Описание задачи не может превышать 1000 символов.");

            RuleFor(v => v.DueDate)
                .NotEmpty().WithMessage("Срок выполнения задачи должен быть указан.")
                .GreaterThanOrEqualTo(DateTime.Today.Date).WithMessage("Срок выполнения не может быть в прошлом.");

            RuleFor(v => v.PriorityId)
                .GreaterThan(0).WithMessage("Id приоритета должен быть указан.");

            RuleFor(v => v.TagIds)
                .NotNull().WithMessage("Список тегов не может быть null.")
                .ForEach(id => id.GreaterThan(0).WithMessage("Id тега должен быть больше 0."));
        }
    }
}