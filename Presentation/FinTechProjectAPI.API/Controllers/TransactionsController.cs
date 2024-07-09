using FinTechProjectAPI.Application.Features.Transactions.Commands.CreateExpenseTransaction;
using FinTechProjectAPI.Application.Features.Transactions.Commands.CreateIncomeTransaction;
using FinTechProjectAPI.Application.Features.Transactions.Queries.GetAll;
using FinTechProjectAPI.Application.Features.Transactions.Queries.GetCurrentBalance;
using FinTechProjectAPI.Application.Features.Transactions.Queries.GetListExpenseTransection;
using FinTechProjectAPI.Application.Features.Transactions.Queries.GetListIncomeTransaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "adm")]
    public class TransactionsController : BaseController
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTransaction()
        {
            GetAllTransactionQueryRequest getAllTransactionQueryRequest = new GetAllTransactionQueryRequest();
            List<GetAllTransactionQueryResponse> responses = await Mediator.Send(getAllTransactionQueryRequest);
            return Ok(responses);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListExpenseTransaction()
        {
           
            GetListExpenseTransactionQueryRequest getListExpenseTransactionQueryRequest = new GetListExpenseTransactionQueryRequest();
            List<GetListExpenseTransactionQueryResponse> responses = await Mediator.Send(getListExpenseTransactionQueryRequest);
            return Ok(responses);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListIncomeTransaction()
        {

           GetListIncomeTransactionQueryRequest getListIncomeTransactionQueryRequest = new GetListIncomeTransactionQueryRequest();
            List<GetListIncomeTransactionQueryResponse> responses = await Mediator.Send(getListIncomeTransactionQueryRequest);
            return Ok(responses);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentBalance()
        {
           GetCurrentBalanceTransactionQueryRequest getCurrentBalanceTransactionQueryRequest = new GetCurrentBalanceTransactionQueryRequest();
            GetCurrentBalanceTransactionQueryResponse response = await Mediator.Send(getCurrentBalanceTransactionQueryRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateIncomeTransaction([FromBody] CreateIncomeTransactionCommandRequest createIncomeTransactionCommandRequest)
        {
            CreateIncomeTransactionCommandResponse response = await Mediator.Send(createIncomeTransactionCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateExpenseTransaction([FromBody] CreateExpenseTransactionCommandRequest createExpenseTransactionCommandRequest)
        {
            CreateExpenseTransactionCommandResponse response = await Mediator.Send(createExpenseTransactionCommandRequest);
            return Ok(response);
        }

        
    }
}
