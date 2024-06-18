using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(Books book);
        Task<List<Books>> GetAllAsync();
        Task<Books> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
