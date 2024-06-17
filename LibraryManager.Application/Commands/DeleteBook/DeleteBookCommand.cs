using MediatR;

namespace LibraryManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommand(int id) : IRequest<Unit>
    {
        public int Id { get; private set; } = id;
    }
}
