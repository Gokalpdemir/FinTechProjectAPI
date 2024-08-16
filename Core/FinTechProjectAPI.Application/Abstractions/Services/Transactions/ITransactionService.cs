using FinTechProjectAPI.Application.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.Abstractions.Services.Transactions;

public interface ITransactionService
{
   public Task<bool>  CreateExpenseTransaction(string categoryId, string description, float amount, DateTime transactionDate);    
   public Task<bool>  CreateIncomeTransaction(string categoryId,string description,float amount,DateTime transactionDate);
    public Task<List<GetListTransactionDto>> GetAllTransactions();
    public Task<List<GetListTransactionDto>> GetListIncomeTransaction();

    public Task<List<GetListTransactionDto>> GetListExpenseTransaction();

    public Task<GetCurrentBalanceDto> GetCurrentBalance();

    public Task<bool> DeleteTransaction(string transactionId);
    


}

