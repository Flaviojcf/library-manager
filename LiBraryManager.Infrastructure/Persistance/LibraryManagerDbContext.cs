using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LiBraryManager.Infrastructure.Persistance
{
    public class LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
