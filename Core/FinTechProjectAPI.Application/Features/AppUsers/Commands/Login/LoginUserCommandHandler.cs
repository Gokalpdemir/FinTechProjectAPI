using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Application.Security.JWT;
using MediatR;

namespace FinTechProjectAPI.Application.Features.AppUsers.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
