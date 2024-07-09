using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.DTOs.Transaction;
using FinTechProjectAPI.Application.Repositories.ExpenseTransactions;
using FinTechProjectAPI.Application.Repositories.IncomeTransactions;
using FinTechProjectAPI.Application.Repositories.Transactions;
using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        private readonly ITransactionReadRepository _transactionReadRepository;
        private readonly IIncomeTransactionReadRepository _incomeTransactionReadRepository;
        private readonly IIncomeTransactionWriteRepository _incomeTransactionWriteRepository;
        private readonly IExpenseTransactionReadRepository _expenseTransactionReadRepository;
        private readonly IExpenseTransactionWriteRepository _expenseTransactionWriteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public TransactionService(
            ITransactionWriteRepository transactionWriteRepository,
            ITransactionReadRepository transactionReadRepository,
            IIncomeTransactionReadRepository incomeTransactionReadRepository,
            IIncomeTransactionWriteRepository incomeTransactionWriteRepository,
            IExpenseTransactionReadRepository expenseTransactionReadRepository,
            IExpenseTransactionWriteRepository expenseTransactionWriteRepository,
            IHttpContextAccessor contextAccessor,
            UserManager<AppUser> userManager)
        {
            _transactionWriteRepository = transactionWriteRepository;
            _transactionReadRepository = transactionReadRepository;
            _incomeTransactionReadRepository = incomeTransactionReadRepository;
            _incomeTransactionWriteRepository = incomeTransactionWriteRepository;
            _expenseTransactionReadRepository = expenseTransactionReadRepository;
            _expenseTransactionWriteRepository = expenseTransactionWriteRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<bool> CreateExpenseTransaction(string categoryId, string description, float amount, DateTime transactionDate)
        {
            var transaction = await CreateBaseTransaction(amount, description, categoryId, transactionDate);
            await _expenseTransactionWriteRepository.AddAsync(new ExpenseTransaction
            {

                Id = Guid.NewGuid(),
                TransactionId = transaction.Id
            });
            await _expenseTransactionWriteRepository.SaveAsync();
            return true;
        }

        public async Task<bool> CreateIncomeTransaction(string categoryId, string description, float amount, DateTime transactionDate)
        {
            var transaction = await CreateBaseTransaction(amount, description, categoryId, transactionDate);
            await _incomeTransactionWriteRepository.AddAsync(new IncomeTransaction
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id
            });
            await _incomeTransactionWriteRepository.SaveAsync();
            return true;
        }

        public async Task<List<GetListTransactionDto>> GetAllTransactions()
        {
            AppUser user = await ContextUser();
            var Transactions = await _transactionReadRepository.Table.Include(t => t.AppUser).Where(t => t.AppUserId == user.Id)
                   .Select(t => new GetListTransactionDto
                   {
                       Amount = t.Amount,
                       Description = t.Description,
                       Category = t.Category.Name,
                       TransactionType = t.Category.Type == 0 ? "Expense" : "Income",
                       TransactionDate = t.TransactionDate,
                   }).ToListAsync();
            return Transactions;
        }

        public async Task<List<GetListTransactionDto>> GetListExpenseTransaction()
        {
            AppUser user = await ContextUser();
            return await _transactionReadRepository.Table.Include(t => t.AppUser).Include(t => t.Category).Include(t => t.ExpenseTransaction).Where(t => t.AppUserId == user.Id && t.ExpenseTransaction != null).Select(t => new GetListTransactionDto
            {
                Amount = t.Amount,
                Description = t.Description,
                Category = t.Category.Name,
                TransactionDate = t.TransactionDate,
                TransactionType = t.Category.Type == 0 ? "Expense" : "Income",
            }).ToListAsync();

        }

        public async Task<List<GetListTransactionDto>> GetListIncomeTransaction()
        {
            AppUser user = await ContextUser();
            return await _transactionReadRepository.Table.Include(t => t.AppUser).Include(t => t.Category).Include(t => t.IncomeTransaction).Where(t => t.AppUserId == user.Id && t.IncomeTransaction != null).Select(t => new GetListTransactionDto
            {
                Amount = t.Amount,
                Description = t.Description,
                Category = t.Category.Name,
                TransactionDate = t.TransactionDate,
                TransactionType = t.Category.Type == 0 ? "Expense" : "Income",
            }).ToListAsync();

        }

        public async Task<GetCurrentBalanceDto> GetCurrentBalance()
        {
            AppUser user = await ContextUser();

            float totalIncome = await _transactionReadRepository.Table
                .Where(t => t.AppUserId == user.Id && t.IncomeTransaction != null)
                .SumAsync(t => t.Amount);

            float totalExpense = await _transactionReadRepository.Table
                .Where(t => t.AppUserId == user.Id && t.ExpenseTransaction != null)
                .SumAsync(t => t.Amount);

            float currentBalance = totalIncome - totalExpense;
          return  new GetCurrentBalanceDto
            {
                CurrentBalance = currentBalance,
                Expense = totalExpense,
                Income = totalIncome,
                UserName = user.UserName
            };
           
        }


        private async Task<Transaction> CreateBaseTransaction(float amount, string description, string categoryId, DateTime transactionDate)
        {
            AppUser user = await ContextUser();

            Transaction transaction = new()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                CategoryId = Guid.Parse(categoryId),
                AppUserId = user.Id,
                Description = description,
                TransactionDate = transactionDate
            };
            await _transactionWriteRepository.AddAsync(transaction);
            return transaction;
        }

        private async Task<AppUser> ContextUser()
        {
            var userName = _contextAccessor?.HttpContext?.User?.Identity?.Name;
            AppUser? user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return user;
            }

            throw new Exception("User Not Found");
        }

       
    }
}
