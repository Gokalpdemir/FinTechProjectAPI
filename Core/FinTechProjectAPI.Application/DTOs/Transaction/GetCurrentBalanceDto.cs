using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.DTOs.Transaction;

public class GetCurrentBalanceDto
{
    public string UserName { get; set; }
    public Double Income { get; set; }
    public Double Expense { get; set; }
    public Double  CurrentBalance { get; set; }
}
