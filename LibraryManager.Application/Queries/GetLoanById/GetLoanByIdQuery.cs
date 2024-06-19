using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery(Guid id) : IRequest<Loans>
    {
        public Guid Id { get; private set; } = id;
    }
}
