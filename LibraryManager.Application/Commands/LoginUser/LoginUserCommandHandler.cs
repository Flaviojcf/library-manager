using LibraryManager.Application.Exceptions;
using LibraryManager.Application.OutPutModels;
using LibraryManager.Domain.Repositories;
using LibraryManager.Domain.Services;
using MediatR;

namespace LibraryManager.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository) : IRequestHandler<LoginUserCommand, LoginUserOutputModel>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAuthService _authService = authService;
        public async Task<LoginUserOutputModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                throw new NotFoundException($"Usuário ou senha incorretos"); ;
            }

            var token = _authService.GenerateJwtToken(user.Email);

            var loginUserOutputModel = new LoginUserOutputModel(user.Email, token);

            return loginUserOutputModel;
        }
    }
}
