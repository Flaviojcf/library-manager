using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync(int id);
        Task<Book> GetByIdAsync(int id);
        Task DeleteAsync(Book book);
    }
}
