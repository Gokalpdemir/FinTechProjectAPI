using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Enums;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CaategoryType Type { get; set; }
    public ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
    public ICollection<IncomeTransaction> IncomeTransactions { get; set; }


}

