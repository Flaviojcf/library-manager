using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetBookById
{
    public class GetBookByIdQuery(Guid id) : IRequest<Books>
    {
        public Guid Id { get; private set; } = id;
    }
}
