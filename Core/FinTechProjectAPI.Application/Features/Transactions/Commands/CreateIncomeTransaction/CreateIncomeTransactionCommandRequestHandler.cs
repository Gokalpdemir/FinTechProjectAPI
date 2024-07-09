using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Commands.CreateIncomeTransaction;

public class CreateIncomeTransactionCommandRequestHandler : IRequestHandler<CreateIncomeTransactionCommandRequest, CreateIncomeTransactionCommandResponse>
{
    private readonly ITransactionService _transactionService;

    public CreateIncomeTransactionCommandRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<CreateIncomeTransactionCommandResponse> Handle(CreateIncomeTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        var succeeded = await _transactionService.CreateIncomeTransaction(request.CategoryId, request.Description, request.Amount, request.TransactionDate);
        return new CreateIncomeTransactionCommandResponse { Succeeded = succeeded };
    }
}
