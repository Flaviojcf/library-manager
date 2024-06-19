using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task AddAsync(Loans loan);
        Task<List<Loans>> GetAllAsync();
        Task<Loans> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
