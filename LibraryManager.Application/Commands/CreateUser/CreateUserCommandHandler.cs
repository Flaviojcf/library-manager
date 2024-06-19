using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Users(request.Name, request.Email);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
