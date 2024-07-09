using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Commands.CreateExpenseTransaction;

public class CreateExpenseTransactionCommandRequestHandler : IRequestHandler<CreateExpenseTransactionCommandRequest, CreateExpenseTransactionCommandResponse>
{
    private readonly ITransactionService _transactionService;

    public CreateExpenseTransactionCommandRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<CreateExpenseTransactionCommandResponse> Handle(CreateExpenseTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        bool succeeded = await _transactionService.CreateExpenseTransaction(request.CategoryId, request.Description, request.Amount, request.TransactionDate);
        return new CreateExpenseTransactionCommandResponse { Succeeded = succeeded };
    }
}
