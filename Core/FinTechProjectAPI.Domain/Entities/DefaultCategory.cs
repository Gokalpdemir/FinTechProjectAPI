using FinTechProjectAPI.Domain.Entities.Common;
using FinTechProjectAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Domain.Entities;

public class DefaultCategory:BaseEntity
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
    public ICollection<Transaction> Transactions { get; set; }

}
