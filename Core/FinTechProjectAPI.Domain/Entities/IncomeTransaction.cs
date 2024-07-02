using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class IncomeTransaction : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid IncomeCategoryId { get; set; }

        public Transaction Transaction { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}
