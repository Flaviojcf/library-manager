using MediatR;

namespace LibraryManager.Application.Commands.UpdateUser
{
    public class UpdateUserCommand(Guid id, string name, string email) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
    }
}
