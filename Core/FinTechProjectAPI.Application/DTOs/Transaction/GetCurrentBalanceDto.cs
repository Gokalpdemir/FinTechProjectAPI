using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Application.DTOs.Transaction;

public class GetCurrentBalanceDto
{
    public string UserName { get; set; }
    public float Income { get; set; }
    public float Expense { get; set; }
    public float  CurrentBalance { get; set; }
}
