namespace TodoApi.Application.UseCases.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQueryValidator : AbstractValidator<GetTodoItemsQuery>
    {
        public GetTodoItemsQueryValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("Id пользователя должен быть указан.");
        }
    }
}