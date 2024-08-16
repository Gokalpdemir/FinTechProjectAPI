using FinTechProjectAPI.Application.Features.Categories.Commands.Create;
using FinTechProjectAPI.Application.Features.Categories.Queries.GetAll;
using FinTechProjectAPI.Application.Features.Categories.Queries.GetByType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="adm")]
    public class CategoriesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await Mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCategoryQueryRequest request = new GetAllCategoryQueryRequest();
            GetAllCategoryQueryResponse responses = await Mediator.Send(request);
            return Ok(responses);
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetByType([FromRoute] int type) 
        {
            GetByTypeCategoryQueryRequest request = new GetByTypeCategoryQueryRequest { Type = type};
            List<GetByTypeCategoryQueryResponse> responses = await Mediator.Send(request);
            return Ok(responses);
        }
    }
}
