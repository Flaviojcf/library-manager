using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.ReduceBookAvailableQuantity
{
    public class ReduceBookAvaillableQuantityCommandHandler(IBookRepository bookRepository) : IRequestHandler<ReduceBookAvaillableQuantityCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Unit> Handle(ReduceBookAvaillableQuantityCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.ReduceAvailableQuantityByGetLoan();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
