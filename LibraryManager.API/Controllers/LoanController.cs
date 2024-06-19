using LibraryManager.Application.Commands.CreateLoan;
using LibraryManager.Application.Commands.DeleteLoan;
using LibraryManager.Application.Commands.PayLoan;
using LibraryManager.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                //var getLoanByIdQuery = new GetLoanByIdQuery(id);

                //var book = await _mediator.Send(getLoanByIdQuery);

                return Ok();
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoanCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
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
                var command = new DeleteLoanCommand(id);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }


        [HttpPut("/payLoan/{id}")]
        public async Task<IActionResult> PayLoan(Guid id, [FromBody] PayLoanCommand command)
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
    }
}
