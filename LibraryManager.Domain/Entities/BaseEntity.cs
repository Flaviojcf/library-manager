namespace LibraryManager.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
