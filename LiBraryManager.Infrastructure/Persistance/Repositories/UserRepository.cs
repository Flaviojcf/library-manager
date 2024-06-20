using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiBraryManager.Infrastructure.Persistance.Repositories
{
    public class UserRepository(LibraryManagerDbContext dbContext) : IUserRepository
    {
        private readonly LibraryManagerDbContext _dbContext = dbContext;

        public async Task AddAsync(Users book)
        {
            await _dbContext.Users.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _dbContext.Users.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<Users> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Users> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
