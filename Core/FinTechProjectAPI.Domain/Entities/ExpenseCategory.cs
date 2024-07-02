using FinTechProjectAPI.Domain.Entities.Common;

namespace FinTechProjectAPI.Domain.Entities
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
    }
}
