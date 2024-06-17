using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null || book.IsActive == false)
            {
                throw new NotFoundException($"O livro com o id {request.Id} não foi encontrado");
            }

            book.DeActive();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
