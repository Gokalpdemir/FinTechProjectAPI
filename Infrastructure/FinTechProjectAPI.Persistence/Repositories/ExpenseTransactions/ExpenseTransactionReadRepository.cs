using FinTechProjectAPI.Application.Repositories.ExpenseTransactions;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Repositories.ExpenseTransactions;

public class ExpenseTransactionReadRepository : ReadRepository<ExpenseTransaction>, IExpenseTransactionReadRepository
{
    public ExpenseTransactionReadRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
public class ExpenseTransactionWriteRepository : WriteRepository<ExpenseTransaction>, IExpenseTransactionWriteRepository
{
    public ExpenseTransactionWriteRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
