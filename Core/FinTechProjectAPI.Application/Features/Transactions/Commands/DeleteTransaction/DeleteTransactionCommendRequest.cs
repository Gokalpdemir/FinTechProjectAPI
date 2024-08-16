using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Transactions.Commands.DeleteTransaction;

public class DeleteTransactionCommendRequest:IRequest<DeleteTransactionCommendResponse>
{
    public string TransactionId { get; set; }
}
