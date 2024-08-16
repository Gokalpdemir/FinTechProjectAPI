using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using MediatR;

namespace FinTechProjectAPI.Application.Features.Transactions.Commands.DeleteTransaction;

public class DeleteTransactionCommendRequestHandler : IRequestHandler<DeleteTransactionCommendRequest, DeleteTransactionCommendResponse>
{
    private readonly ITransactionService _transactionService;

    public DeleteTransactionCommendRequestHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<DeleteTransactionCommendResponse> Handle(DeleteTransactionCommendRequest request, CancellationToken cancellationToken)
    {
       bool response= await  _transactionService.DeleteTransaction(request.TransactionId);
        return new DeleteTransactionCommendResponse { IsSuccess = response };
    }
}
