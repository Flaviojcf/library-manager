using LibraryManager.Domain.Validation;

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
            UpdatedAt = DateTime.Now;
        }

        public void DeActive()
        {
            IsActive = false;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string author, string title, string iSBN, int yearPublication)
        {
            ValidateDomain(author, title, iSBN, yearPublication);
            Author = author;
            Title = title;
            ISBN = iSBN;
            YearPublication = yearPublication;
            UpdatedAt = DateTime.Now;
        }

        private static void ValidateDomain(string author, string title, string iSBN, int yearPublication)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(author), "O campo autor é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "O campo título é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(iSBN), "O campo ISBN é obrigatório");
            DomainExceptionValidation.When(yearPublication <= 0, "O campo ano de publicação é obrigatório");
        }
    }
}
