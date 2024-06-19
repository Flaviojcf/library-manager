using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler(ILoanRepository loanRepository) : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan == null || loan.IsActive == false)
            {
                throw new NotFoundException($"O empréstimo com o id {request.Id} não foi encontrado");
            }

            loan.DeActive();

            await _loanRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
