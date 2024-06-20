using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using LibraryManager.Domain.Services;
using MediatR;

namespace LibraryManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService) : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAuthService _authService = authService;
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new Users(request.Name, request.Email, passwordHash);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }

}
