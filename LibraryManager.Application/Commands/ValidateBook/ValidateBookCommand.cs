using MediatR;

namespace LibraryManager.Application.Commands.ValidateBook
{
    public class ValidateBookCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
