using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetAll;

public class GetAllTransactionQueryRequest:IRequest<List<GetAllTransactionQueryResponse>>
{
}
