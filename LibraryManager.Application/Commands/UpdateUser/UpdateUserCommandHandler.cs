﻿using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException($"O usuário com o id {request.Id} não foi encontrado");
            }

            user.Update(request.Name, request.Email);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
