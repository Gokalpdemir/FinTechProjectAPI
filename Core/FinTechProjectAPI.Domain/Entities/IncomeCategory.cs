using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class IncomeCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<IncomeTransaction> IncomeTransactions { get; set; }
    }
}
