using MediatR;

namespace LibraryManager.Application.Commands.ValidateUser
{
    public class ValidateUserCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
