using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;
using FinTechProjectAPI.Persistence.Repositories;

namespace FinTechProjectAPI.Application.Repositories.IncomeTransactions;

public class IncomeTransactionReadRepository : ReadRepository<IncomeTransaction>, IIncomeTransactionReadRepository
{
    public IncomeTransactionReadRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
