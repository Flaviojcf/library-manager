namespace LibraryManager.Domain.Entities
{
    public sealed class Books(string author, string title, string iSBN, int yearPublication) : BaseEntity
    {
        public string Author { get; private set; } = author;
        public string Title { get; private set; } = title;
        public string ISBN { get; private set; } = iSBN;
        public int YearPublication { get; private set; } = yearPublication;
        public bool IsActive { get; private set; } = true;
        public List<Loans> Loans { get; private set; } = [];

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string author, string title, string iSBN, int yearPublication)
        {
            Author = author;
            Title = title;
            ISBN = iSBN;
            YearPublication = yearPublication;
            UpdatedAt = DateTime.Now;
        }
    }
}
