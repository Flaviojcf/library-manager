using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository, IUserRepository userRepository) : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository = loanRepository;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"O usuário com o id {request.UserId} não foi encontrado");
            }

            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null)
            {
                throw new NotFoundException($"O livro com o id {request.UserId} não foi encontrado");
            }

            var loan = new Loans(request.UserId, request.BookId);

            loan.GetLoan();

            await _loanRepository.AddAsync(loan);

            return loan.Id;
        }
    }
}
