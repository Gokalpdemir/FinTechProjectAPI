using FinTechProjectAPI.Application.Repositories.Categories;
using FinTechProjectAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Repositories.Categories;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(FinTechProjectAPIDbContext context) : base(context)
    {
    }
}
