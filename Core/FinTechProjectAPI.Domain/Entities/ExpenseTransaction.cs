using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class ExpenseTransaction : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid ExpenseCategoryId { get; set; }

        public Transaction Transaction { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
