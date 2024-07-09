using FinTechProjectAPI.Application.Repositories.Transactions;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;

namespace FinTechProjectAPI.Persistence.Repositories.Transactions;

public class TransactionWriteRepository : WriteRepository<Transaction>, ITransactionWriteRepository
{
    public TransactionWriteRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
