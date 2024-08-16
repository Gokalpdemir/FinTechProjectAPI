using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.Abstractions.Services.Transactions;
using FinTechProjectAPI.Application.Repositories.Categories;
using FinTechProjectAPI.Application.Repositories.DefaultCategories;
using FinTechProjectAPI.Application.Repositories.ExpenseTransactions;
using FinTechProjectAPI.Application.Repositories.IncomeTransactions;
using FinTechProjectAPI.Application.Repositories.Transactions;
using FinTechProjectAPI.Domain.Entities.Identity;
using FinTechProjectAPI.Persistence.Context;
using FinTechProjectAPI.Persistence.Repositories.Categories;
using FinTechProjectAPI.Persistence.Repositories.DefaultCategories;
using FinTechProjectAPI.Persistence.Repositories.ExpenseTransactions;
using FinTechProjectAPI.Persistence.Repositories.Transactions;
using FinTechProjectAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Extension
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinTechProjectAPIDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MSSQL")));
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.AllowedUserNameCharacters += "ğĞüÜşŞıİöÖçÇ";
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;

            }).AddEntityFrameworkStores<FinTechProjectAPIDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IExternalAuthenticationService, AuthenticationService>();
            services.AddScoped<IInternalAuthenticationService, AuthenticationService>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
            services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();

            services.AddScoped<IIncomeTransactionReadRepository, IncomeTransactionReadRepository>();
            services.AddScoped<IIncomeTransactionWriteRepository, IncomeTransactionWriteRepository>();

            services.AddScoped<IExpenseTransactionReadRepository, ExpenseTransactionReadRepository>();
            services.AddScoped<IExpenseTransactionWriteRepository, ExpenseTransactionWriteRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITransactionService , TransactionService>();

            services.AddScoped<IDefaultCategoryReadRepository, DefaultCategoryReadRepository>();
            services.AddScoped<IDefaultCategoryWriteRepository, DefaultCategoryWriteRepository>();
        }
    }
}
