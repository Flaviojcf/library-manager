using LibraryManager.Application.OutPutModels;
using MediatR;

namespace LibraryManager.Application.Commands.LoginUser
{
    public class LoginUserCommand(string email, string password) : IRequest<LoginUserOutputModel>
    {
        public string Email { get; private set; } = email;
        public string Password { get; private set; } = password;
    }
}
