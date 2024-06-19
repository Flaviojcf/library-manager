using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetLoanById
{
    public class GetLoanByIdQueryHandler(ILoanRepository loanRepository) : IRequestHandler<GetLoanByIdQuery, Loans>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        public async Task<Loans> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan == null)
            {
                throw new NotFoundException($"A dívida com o id {request.Id} não foi encontrada");
            }

            return loan;
        }
    }
}
