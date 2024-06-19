using MediatR;

namespace LibraryManager.Application.Commands.CreateBook
{
    public class CreateBookCommand(string author, string title, string iSBN, int yearPublication, int totalQuantity, decimal price) : IRequest<Guid>
    {
        public string Author { get; private set; } = author;
        public string Title { get; private set; } = title;
        public string ISBN { get; private set; } = iSBN;
        public int YearPublication { get; private set; } = yearPublication;
        public int TotalQuantity { get; private set; } = totalQuantity;
        public decimal Price { get; private set; } = price;
    }
}
