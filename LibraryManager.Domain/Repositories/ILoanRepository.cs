using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task AddAsync(Loan loan);
    }
}
