using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(Users user);
        Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(Guid id);
        Task<Users> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task SaveChangesAsync();
    }
}
