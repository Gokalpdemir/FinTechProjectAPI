using FinTechProjectAPI.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoryQueryRequest:IRequest<List<GetAllCategoryQueryResponse>>
{
}
