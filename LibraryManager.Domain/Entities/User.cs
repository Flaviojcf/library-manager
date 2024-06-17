namespace LibraryManager.Domain.Entities
{
    public class User(string name, string email) : BaseEntity
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
    }
}
