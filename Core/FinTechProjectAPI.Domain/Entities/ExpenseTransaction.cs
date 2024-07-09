using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class ExpenseTransaction : BaseEntity
    {
        public Guid TransactionId { get; set; }

        public Transaction Transaction { get; set; }
    }
}

