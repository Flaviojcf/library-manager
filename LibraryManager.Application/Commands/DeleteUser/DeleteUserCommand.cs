using MediatR;

namespace LibraryManager.Application.Commands.DeleteUser
{
    public class DeleteUserCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
