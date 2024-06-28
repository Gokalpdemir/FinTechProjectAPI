using FinTechProjectAPI.Application.Features.AppUsers.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse reponse= await _mediator.Send(loginUserCommandRequest);
            return Ok(reponse);
        }
    }
}
