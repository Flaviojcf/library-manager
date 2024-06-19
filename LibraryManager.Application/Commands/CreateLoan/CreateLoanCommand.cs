using MediatR;

namespace LibraryManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommand(Guid userId, Guid bookId) : IRequest<Guid>
    {
        public Guid UserId { get; private set; } = userId;
        public Guid BookId { get; private set; } = bookId;
    }
}
