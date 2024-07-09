using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetListExpenseTransection;

public class GetListExpenseTransactionQueryRequestHandler : IRequestHandler<GetListExpenseTransactionQueryRequest, List<GetListExpenseTransactionQueryResponse>>
{
    private readonly ITransactionService _transactionService;

    public GetListExpenseTransactionQueryRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<List<GetListExpenseTransactionQueryResponse>> Handle(GetListExpenseTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        List<GetListTransactionDto> expenseTransactions = await _transactionService.GetListExpenseTransaction();
        return expenseTransactions.Select(et => new GetListExpenseTransactionQueryResponse
        {
            Amount = et.Amount,
            Description = et.Description,
            Category = et.Category,
            TransactionType = et.TransactionType,
            TransactionDate = et.TransactionDate,
        }).ToList();
    }
}
