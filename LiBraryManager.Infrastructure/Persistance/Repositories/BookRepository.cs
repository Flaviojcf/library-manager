using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiBraryManager.Infrastructure.Persistance.Repositories
{
    public class BookRepository(LibraryManagerDbContext dbContext) : IBookRepository
    {
        private readonly LibraryManagerDbContext _dbContext = dbContext;

        public async Task AddAsync(Books book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Books>> GetAllAsync()
        {
            return await _dbContext.Books.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<Books> GetByIdAsync(Guid id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
