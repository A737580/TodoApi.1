using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.UseCases.Users.Commands.CreateUser;

namespace TodoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator; 

        public UsersController(ISender mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId); 
        }
    }
}