namespace FinTechProjectAPI.Application.Features.Transactions.Queries.GetListIncomeTransaction;

public class GetListIncomeTransactionQueryResponse
{
    public float Amount { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
}
