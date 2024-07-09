﻿using FinTechProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Repositories.Transactions;

public interface ITransactionReadRepository:IReadRepository<Transaction>
{
}
