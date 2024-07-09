using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetCurrentBalance;

public class GetCurrentBalanceTransactionQueryRequest:IRequest<GetCurrentBalanceTransactionQueryResponse>
{
}
public class GetCurrentBalanceTransactionQueryResponse
{
    public string UserName { get; set; }
    public float Income { get; set; }
    public float Expense { get; set; }
    public float CurrentBalance { get; set; }
}
public class GetCurrentBalanceTransactionQueryRequestHandler : IRequestHandler<GetCurrentBalanceTransactionQueryRequest, GetCurrentBalanceTransactionQueryResponse>
{
    private readonly ITransactionService _transactionService;

    public GetCurrentBalanceTransactionQueryRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<GetCurrentBalanceTransactionQueryResponse> Handle(GetCurrentBalanceTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        GetCurrentBalanceDto currentBalance = await _transactionService.GetCurrentBalance();
        return new GetCurrentBalanceTransactionQueryResponse 
        {
            CurrentBalance=currentBalance.CurrentBalance,
            Income=currentBalance.Income,
            Expense=currentBalance.Expense,
            UserName=currentBalance.UserName,
        };
    }
}
