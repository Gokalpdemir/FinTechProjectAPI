namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetCurrentBalance;

public class GetCurrentBalanceTransactionQueryResponse
{
    public string UserName { get; set; }
    public Double Income { get; set; }
    public Double Expense { get; set; }
    public Double CurrentBalance { get; set; }
}
