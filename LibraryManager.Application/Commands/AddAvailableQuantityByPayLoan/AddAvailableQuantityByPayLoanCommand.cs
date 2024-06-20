using MediatR;

namespace LibraryManager.Application.Commands.AddAvailableQuantityByPayLoan
{
    public class AddAvailableQuantityByPayLoanCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
