using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;
using FinTechProjectAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Repositories.IncomeTransactions;

public class IncomeTransactionWriteRepository : WriteRepository<IncomeTransaction>, IIncomeTransactionWriteRepository
{
    public IncomeTransactionWriteRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
