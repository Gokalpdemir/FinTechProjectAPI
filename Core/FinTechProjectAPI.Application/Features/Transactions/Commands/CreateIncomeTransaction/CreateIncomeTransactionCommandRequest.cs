using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Transactions.Commands.CreateIncomeTransaction;

public class CreateIncomeTransactionCommandRequest : IRequest<CreateIncomeTransactionCommandResponse>
{
    public string CategoryId { get; set; }
    public string Description { get; set; }
    public float Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}
