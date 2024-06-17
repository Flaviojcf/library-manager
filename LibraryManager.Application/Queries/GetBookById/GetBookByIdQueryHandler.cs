using LibraryManager.Application.Exceptions;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, Books>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Books> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException($"O livro com o id {request.Id} não foi encontrado");
            }

            return book;
        }
    }
}
