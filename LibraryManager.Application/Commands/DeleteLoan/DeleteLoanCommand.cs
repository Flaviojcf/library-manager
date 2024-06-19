using MediatR;

namespace LibraryManager.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
