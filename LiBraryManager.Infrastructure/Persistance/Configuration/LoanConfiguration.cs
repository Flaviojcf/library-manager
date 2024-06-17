using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiBraryManager.Infrastructure.Persistance.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loans>
    {
        public void Configure(EntityTypeBuilder<Loans> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.User)
                   .WithMany(u => u.Loans)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Book)
                   .WithMany(b => b.Loans)
                   .HasForeignKey(b => b.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
