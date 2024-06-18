using LibraryManager.Domain.Validation;

namespace LibraryManager.Domain.Entities
{
    public sealed class Users : BaseEntity
    {
        public Users(string name, string email)
        {
            ValidateDomain(name, email);
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public List<Loans> Loans { get; private set; } = [];
        public bool IsActive { get; private set; } = true;

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

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

        private static void ValidateDomain(string name, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O campo email é obrigatório");
        }
    }
}
