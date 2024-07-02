using FinTechProjectAPI.Domain.Entities;
using FinTechProjectAPI.Domain.Entities.Common;
using FinTechProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Context
{
    public class FinTechProjectAPIDbContext:IdentityDbContext<AppUser,AppRole,string>
    {

        public FinTechProjectAPIDbContext()
        {
            
        }
        public FinTechProjectAPIDbContext(DbContextOptions<FinTechProjectAPIDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Transaction>().HasKey(t => t.Id);

            builder.Entity<Transaction>()
                .HasOne(t=>t.IncomeTransaction)
                .WithOne(ıt=>ıt.Transaction)
                .HasForeignKey<IncomeTransaction>(ıt=>ıt.TransactionId);

            builder.Entity<Transaction>()
               .HasOne(t => t.ExpenseTransaction)
               .WithOne(et => et.Transaction)
               .HasForeignKey<ExpenseTransaction>(et => et.TransactionId);



            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if(data.State==EntityState.Added)
                    data.Entity.CreatedDate= DateTime.Now;
                if(data.State==EntityState.Modified)
                    data.Entity.UpdatedDate= DateTime.Now;

            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
