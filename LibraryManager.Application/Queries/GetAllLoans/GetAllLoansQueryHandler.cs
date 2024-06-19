using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler(ILoanRepository loanRepository) : IRequestHandler<GetAllLoansQuery, List<Loans>>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        public async Task<List<Loans>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetAllAsync();
        }
    }
}
