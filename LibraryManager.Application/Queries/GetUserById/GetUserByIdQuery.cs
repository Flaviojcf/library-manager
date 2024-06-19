using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetUserById
{
    public class GetUserByIdQuery(Guid id) : IRequest<Users>
    {
        public Guid Id { get; private set; } = id;
    }
}
