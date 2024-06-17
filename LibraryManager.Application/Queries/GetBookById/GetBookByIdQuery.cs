using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetBookById
{
    public class GetBookByIdQuery(int id) : IRequest<Books>
    {
        public int Id { get; private set; } = id;
    }
}
