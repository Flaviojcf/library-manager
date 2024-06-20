using LibraryManager.Domain.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.AddAvailableQuantityByPayLoan
{
    public class AddAvailableQuantityByPayLoanCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddAvailableQuantityByPayLoanCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        public async Task<Unit> Handle(AddAvailableQuantityByPayLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.AddAvailableQuantityByPayLoan();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
