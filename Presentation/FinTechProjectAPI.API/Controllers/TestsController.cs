using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="adm")]

    
    public class TestsController : ControllerBase
    {

        [HttpGet]
       public async Task<IActionResult> Get()
        {
            return Ok("asdasdad");
        }
    }
}
