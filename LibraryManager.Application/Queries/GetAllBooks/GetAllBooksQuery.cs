using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery(string query) : IRequest<List<Books>>
    {
        public string Query { get; private set; } = query;
    }
}
