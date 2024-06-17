using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException($"O livro com o id {request.Id} não foi encontrado");
            }

            book.Update(request.Author, request.Title, request.ISBN, request.YearPublication);

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
