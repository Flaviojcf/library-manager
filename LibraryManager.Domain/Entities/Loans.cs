namespace LibraryManager.Domain.Entities
{
    public sealed class Loans(Guid userId, Guid bookId) : BaseEntity
    {
        public Users? User { get; private set; }
        public Guid UserId { get; private set; } = userId;
        public Books? Book { get; private set; }
        public Guid BookId { get; private set; } = bookId;
        public DateTime LoanDate { get; private set; }
        public DateTime LoanTime { get; private set; }
        public DateTime? DevolutionDate { get; private set; }
        public bool IsReturned { get; private set; } = false;

        public bool IsActive { get; private set; } = true;

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

        public void GetLoan()
        {
            LoanDate = DateTime.Now;
            LoanTime = DateTime.Now.AddDays(30);
        }

        public void ReturnLoan()
        {
            IsReturned = true;
            DevolutionDate = DateTime.Now;
            IsActive = false;
        }

        public bool IsOverdue()
        {
            if (IsReturned)
            {
                return DevolutionDate > LoanTime;
            }

            return false;
        }
    }
}
