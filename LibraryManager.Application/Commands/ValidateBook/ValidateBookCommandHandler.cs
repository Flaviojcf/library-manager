using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.ValidateBook
{
    public class ValidateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<ValidateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Unit> Handle(ValidateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException($"O livro com o id {request.Id} não foi encontrado");
            }

            if (book.AvailableQuantity == 0)
            {
                throw new BookNotAvailableException($"O livro com o id {request.Id} não está disponível no momento");
            }

            return Unit.Value;
        }
    }
}
