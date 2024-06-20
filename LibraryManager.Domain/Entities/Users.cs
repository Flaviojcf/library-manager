using LibraryManager.Domain.Validation;
using System.Text.Json.Serialization;

namespace LibraryManager.Domain.Entities
{
    public sealed class Users : BaseEntity
    {
        public Users(string name, string email, string password)
        {
            ValidateDomain(name, email, password);
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }

        [JsonIgnore]
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

        private static void ValidateDomain(string name, string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O campo email é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "O campo senha é obrigatório");
        }
    }
}
