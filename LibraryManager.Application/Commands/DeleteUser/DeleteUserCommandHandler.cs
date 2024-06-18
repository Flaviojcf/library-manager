using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null || user.IsActive == false)
            {
                throw new NotFoundException($"O usuário com o id {request.Id} não foi encontrado");
            }

            user.DeActive();

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
