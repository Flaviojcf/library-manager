namespace LibraryManager.Domain.Entities
{
    public class Book(string author, string title, string iSBN, int yearPublication) : BaseEntity
    {
        public string Author { get; private set; } = author;
        public string Title { get; private set; } = title;
        public string ISBN { get; private set; } = iSBN;
        public int YearPublication { get; private set; } = yearPublication;
        public List<Loan> Loans { get; private set; } = [];
    }
}
