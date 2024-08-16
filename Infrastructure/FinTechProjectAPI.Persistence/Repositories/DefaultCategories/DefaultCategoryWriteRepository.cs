using FinTechProjectAPI.Application.Repositories.DefaultCategories;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Repositories.DefaultCategories;

public class DefaultCategoryWriteRepository : WriteRepository<DefaultCategory>, IDefaultCategoryWriteRepository
{
    public DefaultCategoryWriteRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
