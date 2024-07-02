using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class IncomeTransaction : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid CategoryId { get; set; }

        public Transaction Transaction { get; set; }
        public Category Category { get; set; }
    }
}
