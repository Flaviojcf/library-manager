using MediatR;

namespace LibraryManager.Application.Commands.ReduceBookAvailableQuantity
{
    public class ReduceBookAvaillableQuantityCommand(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}
