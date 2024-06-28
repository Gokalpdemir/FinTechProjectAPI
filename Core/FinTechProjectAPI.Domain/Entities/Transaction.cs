using FinTechProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Domain.Entities
{
    public class Transaction:BaseEntity
    {
        public int Amount { get; set; }
    }
}
