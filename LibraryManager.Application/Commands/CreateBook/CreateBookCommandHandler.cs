using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Books(request.Author, request.Title, request.ISBN, request.YearPublication);

            await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
