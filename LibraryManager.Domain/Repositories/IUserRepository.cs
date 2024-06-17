using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsyn(User user);
    }
}
