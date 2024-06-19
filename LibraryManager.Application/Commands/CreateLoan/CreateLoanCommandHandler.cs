using LibraryManager.Application.Commands.ValidateBook;
using LibraryManager.Application.Commands.ValidateUser;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler(ILoanRepository loanRepository, IMediator mediator) : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        private readonly IMediator _mediator = mediator;
        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ValidateUserCommand(request.UserId), cancellationToken);

            await _mediator.Send(new ValidateBookCommand(request.BookId), cancellationToken);

            var loan = new Loans(request.UserId, request.BookId);

            loan.GetLoan();

            await _loanRepository.AddAsync(loan);

            return loan.Id;
        }
    }
}
