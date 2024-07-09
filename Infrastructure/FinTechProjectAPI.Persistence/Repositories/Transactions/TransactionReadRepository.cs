using FinTechProjectAPI.Application.Repositories.Transactions;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Repositories.Transactions;

public class TransactionReadRepository : ReadRepository<Transaction>, ITransactionReadRepository
{
    public TransactionReadRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
