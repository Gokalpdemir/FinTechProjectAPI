using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetCurrentBalance;

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
