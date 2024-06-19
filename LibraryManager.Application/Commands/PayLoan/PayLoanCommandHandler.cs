using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.PayLoan
{
    public class PayLoanCommandHandler(ILoanRepository loanRepository) : IRequestHandler<PayLoanCommand, Loans>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        public async Task<Loans> Handle(PayLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan == null || loan.IsActive == false)
            {
                throw new NotFoundException($"O empréstimo com o id {request.Id} não foi encontrado");
            }

            loan.ReturnLoan();

            await _loanRepository.SaveChangesAsync();

            return loan;
        }
    }
}
