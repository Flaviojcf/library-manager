﻿using LibraryManager.Application.Commands.CreateLoan;
using LibraryManager.Application.Commands.DeleteLoan;
using LibraryManager.Application.Commands.PayLoan;
using LibraryManager.Application.Exceptions;
using LibraryManager.Application.Queries.GetAllLoans;
using LibraryManager.Application.Queries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var getLoanByIdQuery = new GetLoanByIdQuery(id);

                var loan = await _mediator.Send(getLoanByIdQuery);

                return Ok(loan);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            try
            {
                var getAllLoansQuery = new GetAllLoansQuery(query);

                var loans = await _mediator.Send(getAllLoansQuery);

                return Ok(loans);
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
            catch (BookNotAvailableException ex)
            {
                throw new BookNotAvailableException(ex.Message);
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
