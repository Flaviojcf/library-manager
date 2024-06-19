using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery(string query) : IRequest<List<Loans>>
    {
        public string Query { get; private set; } = query;
    }
}
