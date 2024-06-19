using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiBraryManager.Infrastructure.Persistance.Repositories
{
    public class LoanRepository(LibraryManagerDbContext dbContext) : ILoanRepository
    {
        private readonly LibraryManagerDbContext _dbContext = dbContext;

        public async Task AddAsync(Loans loan)
        {
            await _dbContext.Loans.AddAsync(loan);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Loans>> GetAllAsync()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<Loans> GetByIdAsync(Guid id)
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == id);
        }
    }
}
