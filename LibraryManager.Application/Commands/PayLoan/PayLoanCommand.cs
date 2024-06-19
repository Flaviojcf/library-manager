using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.PayLoan
{
    public class PayLoanCommand(Guid id) : IRequest<Loans>
    {
        public Guid Id { get; private set; } = id;
    }
}
