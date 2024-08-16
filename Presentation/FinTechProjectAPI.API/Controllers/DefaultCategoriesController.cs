using FinTechProjectAPI.Application.Features.DefaultCategories.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultCategoriesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateDefaultCategoryCommandRequest createDefaultCategoryCommandRequest)
        {
            CreateDefaultCategoryCommandResponse response = await Mediator.Send(createDefaultCategoryCommandRequest);
            return Ok(response);
        }
    }
}
