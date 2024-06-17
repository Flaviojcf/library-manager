namespace LibraryManager.Domain.Entities
{
    public class Loan(int userId, int bookId) : BaseEntity
    {
        public User? User { get; private set; }
        public int UserId { get; private set; } = userId;
        public Book? Book { get; private set; }
        public int BookId { get; private set; } = bookId;
        public DateTime LoanDate { get; private set; }
        public DateTime LoanTime { get; private set; }
        public DateTime? DevolutionDate { get; private set; }
        public bool IsReturned { get; private set; } = false;

        public void GetLoan()
        {
            LoanDate = DateTime.Now;
            LoanTime = DateTime.Now.AddDays(30);
        }

        public void ReturnLoan()
        {
            IsReturned = true;
            DevolutionDate = DateTime.Now;
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
