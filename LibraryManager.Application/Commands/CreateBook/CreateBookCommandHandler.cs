using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Books(request.Author, request.Title, request.ISBN, request.YearPublication, request.TotalQuantity, request.Price);

            await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
