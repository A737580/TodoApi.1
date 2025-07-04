
namespace TodoApi.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; } 
}
