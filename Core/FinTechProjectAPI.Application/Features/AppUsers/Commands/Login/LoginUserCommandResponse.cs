using FinTechProjectAPI.Application.Security.JWT;

namespace FinTechProjectAPI.Application.Features.AppUsers.Commands.Login
{
    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
}
