using LibraryManager.Application.Commands.CreateUser;
using LibraryManager.Application.Commands.DeleteUser;
using LibraryManager.Application.Commands.LoginUser;
using LibraryManager.Application.Commands.UpdateUser;
using LibraryManager.Application.Exceptions;
using LibraryManager.Application.Queries.GetAllUsers;
using LibraryManager.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);

            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var getUserByIdQuery = new GetUserByIdQuery(id);

                var user = await _mediator.Send(getUserByIdQuery);

                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand command)
        {
            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var loginUserOutputModel = await _mediator.Send(command);

                return Ok(loginUserOutputModel);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }
    }
}
