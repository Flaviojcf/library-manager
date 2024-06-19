using LibraryManager.Domain.Validation;
using System.Text.Json.Serialization;

namespace LibraryManager.Domain.Entities
{
    public sealed class Books : BaseEntity
    {
        public Books(string author, string title, string iSBN, int yearPublication, int totalQuantity, decimal price)
        {
            ValidateCreateDomain(author, title, iSBN, yearPublication, totalQuantity, price);
            Author = author;
            Title = title;
            ISBN = iSBN;
            YearPublication = yearPublication;
            TotalQuantity = totalQuantity;
            AvailableQuantity = totalQuantity;
            Price = price;
        }

        public string Author { get; private set; }
        public string Title { get; private set; }
        public int TotalQuantity { get; private set; }
        public int AvailableQuantity { get; private set; }
        public decimal Price { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublication { get; private set; }
        public bool IsActive { get; private set; } = true;

        [JsonIgnore]
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

        public void ReduceAvailableQuantityByGetLoan()
        {
            AvailableQuantity = AvailableQuantity - 1;
            UpdatedAt = DateTime.Now;
        }

        public void AddAvailableQuantityByPayLoan()
        {
            AvailableQuantity = AvailableQuantity + 1;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string author, string title, string iSBN, int yearPublication)
        {
            ValidateUpdateDomain(author, title, iSBN, yearPublication);
            Author = author;
            Title = title;
            ISBN = iSBN;
            YearPublication = yearPublication;
            UpdatedAt = DateTime.Now;
        }

        private static void ValidateCreateDomain(string author, string title, string iSBN, int yearPublication, int totalQuantity, decimal price)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(author), "O campo autor é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "O campo título é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(iSBN), "O campo ISBN é obrigatório");
            DomainExceptionValidation.When(yearPublication <= 0, "O campo ano de publicação é obrigatório");
            DomainExceptionValidation.When(totalQuantity <= 0, "O campo quantidade total é obrigatório");
            DomainExceptionValidation.When(price <= 0, "O campo preço é obrigatório");
        }

        private static void ValidateUpdateDomain(string author, string title, string iSBN, int yearPublication)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(author), "O campo autor é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "O campo título é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(iSBN), "O campo ISBN é obrigatório");
            DomainExceptionValidation.When(yearPublication <= 0, "O campo ano de publicação é obrigatório");
        }
    }
}
