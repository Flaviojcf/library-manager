using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LiBraryManager.Infrastructure.Persistance
{
    public class LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Loans> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
