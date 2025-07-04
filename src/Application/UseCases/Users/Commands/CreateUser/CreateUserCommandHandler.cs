using TodoApi.Application.Common.Interfaces; 
using TodoApi.Domain.Entities; 

namespace TodoApi.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = request.Password, 
            Created = DateTimeOffset.UtcNow,
            LastModified = DateTimeOffset.UtcNow
        };

        _context.Users.Add(user); 

        await _context.SaveChangesAsync(cancellationToken); 

        return user.Id; 
    }
}
