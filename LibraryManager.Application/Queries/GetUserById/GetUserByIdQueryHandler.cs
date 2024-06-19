using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, Users>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException($"O usuário com o id {request.Id} não foi encontrado");
            }

            return user;
        }
    }
}
