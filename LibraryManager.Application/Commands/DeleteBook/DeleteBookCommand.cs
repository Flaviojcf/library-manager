using MediatR;

namespace LibraryManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
