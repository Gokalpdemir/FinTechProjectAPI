using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetAll;

public class GetAllTransactionQueryRequestHandler : IRequestHandler<GetAllTransactionQueryRequest, List<GetAllTransactionQueryResponse>>
{
    private readonly ITransactionService _transactionService;

    public GetAllTransactionQueryRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<List<GetAllTransactionQueryResponse>> Handle(GetAllTransactionQueryRequest request, CancellationToken cancellationToken)
    {
       List<GetListTransactionDto> transactions= await  _transactionService.GetAllTransactions();
        return transactions.Select(t=> new GetAllTransactionQueryResponse
        {
            Amount = t.Amount,
            Description = t.Description,
            Category = t.Category,
            TransactionType = t.TransactionType,
            TransactionDate = t.TransactionDate,
        }).ToList();
        
    }
}
