using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.Security.JWT;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinTechProjectAPI.Application.Features.AppUsers.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<LoginUserCommandHandler> _logger;
        public LoginUserCommandHandler(IAuthenticationService authenticationService, ILogger<LoginUserCommandHandler> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
           Token token = await _authenticationService.loginAsync(request.UserNameOrEmail,request.Password,30);
            

            return new LoginUserCommandResponse()
            {
               Token = token,
            };
        }
    }
}
