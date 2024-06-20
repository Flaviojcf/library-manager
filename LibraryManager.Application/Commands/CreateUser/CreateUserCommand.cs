using MediatR;

namespace LibraryManager.Application.Commands.CreateUser
{
    public class CreateUserCommand(string name, string email, string password) : IRequest<Guid>
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Password { get; set; } = password;
    }
}
