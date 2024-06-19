using LibraryManager.Domain.Entities;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery(string query) : IRequest<List<Users>>
    {
        public string Query { get; private set; } = query;
    }
}
