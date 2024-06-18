using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsyn(Users user);
        Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
