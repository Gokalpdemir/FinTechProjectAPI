using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Entities.Common;
using FinTechProjectAPI.Domain.Enums;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
    public ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
    public ICollection<IncomeTransaction> IncomeTransactions { get; set; }

    public Category()
    {
        ExpenseTransactions=new HashSet <ExpenseTransaction>();
        IncomeTransactions = new HashSet <IncomeTransaction>();

    }


}

