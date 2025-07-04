using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.UseCases.TodoItems.Commands.CreateTodoItem;
using TodoApi.Application.UseCases.TodoItems.Queries.GetTodoItems;
using TodoApi.Application.Common.Models; 

namespace TodoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ISender _mediator;  

        public TodoItemsController(ISender mediator)  
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            var todoItemId = await _mediator.Send(command);
            return Ok(todoItemId);  
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<List<TodoItemDto>>> GetByUserId(int userId)
        {
            var query = new GetTodoItemsQuery { UserId = userId };
            var todoItems = await _mediator.Send(query);
            return Ok(todoItems);  
        }
    }
}