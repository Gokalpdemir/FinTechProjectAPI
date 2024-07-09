using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetListIncomeTransaction;

public class GetListIncomeTransactionQueryRequestHandler : IRequestHandler<GetListIncomeTransactionQueryRequest, List<GetListIncomeTransactionQueryResponse>>
{
    private readonly ITransactionService _transactionService;

    public GetListIncomeTransactionQueryRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<List<GetListIncomeTransactionQueryResponse>> Handle(GetListIncomeTransactionQueryRequest request, CancellationToken cancellationToken)
    {
        List<GetListTransactionDto> ıncomeTransactions = await _transactionService.GetListIncomeTransaction();
        return ıncomeTransactions.Select(ıt=> new GetListIncomeTransactionQueryResponse
        {
            Amount = ıt.Amount,
            Category=ıt.Category,
            Description=ıt.Description,
            TransactionDate=ıt.TransactionDate,
            TransactionType=ıt.TransactionType,
        }).ToList();
    }
}
