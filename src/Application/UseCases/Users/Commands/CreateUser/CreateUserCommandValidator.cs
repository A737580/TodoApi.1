
namespace TodoApi.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Username)
            .NotEmpty().WithMessage("Имя пользователя не может быть пустым.")
            .MaximumLength(50).WithMessage("Имя пользователя не может превышать 50 символов.");

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email не может быть пустым.")
            .EmailAddress().WithMessage("Некорректный формат Email.");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Пароль не может быть пустым.")
            .MinimumLength(6).WithMessage("Пароль должен содержать не менее 6 символов.")
            .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву.")
            .Matches("[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву.")
            .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру.");
    }
}
