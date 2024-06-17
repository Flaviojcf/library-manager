namespace LibraryManager.Domain.Entities
{
    public sealed class Users(string name, string email) : BaseEntity
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public List<Loans> Loans { get; private set; } = [];

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
