using FinTechProjectAPI.Domain.Entities.Common;
using FinTechProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string AppUserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public Category Category { get; set; }
        public AppUser AppUser { get; set; }
        public IncomeTransaction IncomeTransaction { get; set; }
        public ExpenseTransaction ExpenseTransaction { get; set; }
    }
}
