using System.Text.Json.Serialization;

namespace LibraryManager.Domain.Entities
{
    public sealed class Loans(Guid userId, Guid bookId) : BaseEntity
    {
        [JsonIgnore]
        public Users? User { get; private set; }
        public Guid UserId { get; private set; } = userId;

        [JsonIgnore]
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
            UpdatedAt = DateTime.Now;
        }

        public void ReturnLoan()
        {
            IsReturned = true;
            DevolutionDate = DateTime.Now;
            UpdatedAt = DateTime.Now;
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
