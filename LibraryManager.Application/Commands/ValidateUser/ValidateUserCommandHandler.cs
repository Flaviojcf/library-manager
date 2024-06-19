using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.ValidateUser
{
    public class ValidateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<ValidateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Unit> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException($"O usuário com o id {request.Id} não foi encontrado");
            }

            return Unit.Value;
        }
    }
}
